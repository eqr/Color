using System;
using System.Collections.Generic;
using System.Linq;

namespace DDDConcepts
{
    public partial class Order
    {
        public bool IsApproved { get; protected set; }
        public IEnumerable<OrderHistoryEntry> HistoryEntries
        {
            get { return historyEntries; }
        }
        public void Approve()
        {
            IsApproved = true;

            var orderHistoryEntry = new OrderHistoryEntry(this, OrderHistoryType.Approved);

            historyEntries.Add(orderHistoryEntry);
        }
    }
}