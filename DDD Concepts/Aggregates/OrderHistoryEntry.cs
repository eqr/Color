namespace DDDConcepts
{
    public class OrderHistoryEntry
    {
        private Order order;
        private object approved;

        public OrderHistoryEntry(Order order, object approved)
        {
            this.order = order;
            this.approved = approved;
        }
    }
}