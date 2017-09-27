// A repository.
using System;

public interface IPurchaseOrderRepository
    {
        PurchaseOrder Get(string id);
        // The commit method would likely be moved to a Unit of Work managed by infrastructure.
        void Commit();
    }

    // A marker interface for a domain event.
    public interface IDomainEvent { }

    // A local domain event publisher.
    public static class DomainEvents
    {
        public static void Raise<TEvent>(TEvent domainEvent) where TEvent : IDomainEvent
        {
            // see: http://www.udidahan.com/2009/06/14/domain-events-salvation/
            // and: http://lostechies.com/jimmybogard/2010/04/08/strengthening-your-domain-domain-events/
        }
    }

    // The root entity of the PO aggregate - aggregate root.
    public class PurchaseOrder
    {
        public string Id { get; private set; }
        public string VendorId { get; private set; }
        public string PONumber { get; private set; }
        public string Description { get; private set; }
        public decimal Total { get; private set; }
        public DateTime SubmissionDate { get; private set; }
        public ICollection<Invoice> Invoices { get; private set; }

        public decimal InvoiceTotal
        {
            get { return this.Invoices.Select(x => x.Amount).Sum(); }
        }

        public bool IsFullyInvoiced
        {
            get { return this.Total <= this.InvoiceTotal; }
        }

        bool ContainsInvoice(string vendorInvoiceNumber)
        {
            return this.Invoices.Any(x => x.VendorInvoiceNumber.Equals(vendorInvoiceNumber, StringComparison.OrdinalIgnoreCase));
        }

        public Invoice Invoice(IInvoiceNumberGenerator generator, string vendorInvoiceNumber, DateTime date, decimal amount)
        {
            // These guards maintain business integrity of the PO.
            if (this.IsFullyInvoiced)
                throw new Exception("The PO is fully invoiced.");
            if (ContainsInvoice(vendorInvoiceNumber))
                throw new Exception("Duplicate invoice!");

            var invoiceNumber = generator.GenerateInvoiceNumber(this.VendorId, vendorInvoiceNumber, date);

            var invoice = new Invoice(invoiceNumber, vendorInvoiceNumber, date, amount);
            this.Invoices.Add(invoice);
            DomainEvents.Raise(new PurchaseOrderInvoicedEvent(this.Id, invoice.InvoiceNumber));
            return invoice;
        }
    }

    // A domain event.
    public class PurchaseOrderInvoicedEvent : IDomainEvent
    {
        public PurchaseOrderInvoicedEvent(string purchaseOrderId, string invoiceNumber)
        {
            this.PurchaseOrderId = purchaseOrderId;
            this.InvoiceNumber = invoiceNumber;
        }

        public string PurchaseOrderId { get; private set; }
        public string InvoiceNumber { get; private set; }
    }

    // A value object. In production scenarios this would likely be an entity or even an aggregate.
    public class Invoice
    {
        public Invoice(string vendorInvoiceNumber, string invoiceNumber, DateTime date, decimal amount)
        {
            this.VendorInvoiceNumber = vendorInvoiceNumber;
            this.InvoiceNumber = invoiceNumber;
            this.InvoiceDate = date;
            this.Amount = amount;
        }

        // The invoice number provided by the vendor. 
        public string VendorInvoiceNumber { get; private set; }
        // The internal invoice number is used for internal lookups and is ensured to be unique and readable.
        public string InvoiceNumber { get; private set; }
        public DateTime InvoiceDate { get; private set; }
        public decimal Amount { get; private set; }
    }

    // A domain service used for generating unique and user-friendly invoice numbers.
    public interface IInvoiceNumberGenerator
    {
        string GenerateInvoiceNumber(string vendorId, string vendorInvoiceNumber, DateTime invoiceDate);
    }

    // The application service. Can either delegate to a domain model, as in this example, or a transaction script.
    public class PurchaseOrderService
    {
        public PurchaseOrderService(IPurchaseOrderRepository repository, IInvoiceNumberGenerator invoiceNumberGenerator)
        {
            this.repository = repository;
            this.invoiceNumberGenerator = invoiceNumberGenerator;
        }

        readonly IPurchaseOrderRepository repository;
        readonly IInvoiceNumberGenerator invoiceNumberGenerator;

        public void Invoice(string purchaseOrderId, string vendorInvoiceNumber, DateTime date, decimal amount)
        {
            // Transaction management, along with committing the unit of work can be moved to ambient infrastructure.
            using (var ts = new TransactionScope())
            {
                var purchaseOrder = this.repository.Get(purchaseOrderId);
                if (purchaseOrder == null)
                    throw new Exception("PO not found!");
                purchaseOrder.Invoice(this.invoiceNumberGenerator, vendorInvoiceNumber, date, amount);
                this.repository.Commit();
                ts.Complete();
            }
        }
    }