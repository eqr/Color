using System;
using System.Collections.Generic;
using System.Linq;

namespace DDDConcepts
{
    public class Order
    {
        private readonly List<OrderHistoryEntry> historyEntries;
        private readonly List<Product> products;
        public IEnumerable<Product> Products
        {
            get { return products; }
        }
        public Client Client { get; protected set; }

        public Order(IEnumerable<Product> products, Client client)
        {
            if (products == null)
                throw new ArgumentNullException("products");

            if (client == null)
                throw new ArgumentNullException("client");

            Client = client;
            products = products.ToList();
        }
        public void AddProduct(Product product)
        {
            product.Order = this;
            products.Add(product);
        }
    }
}