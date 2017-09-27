using System.Collections.Generic;

namespace DDDConcepts
{
    public class Basket
    {
        private BasketItems items;
        private Guid id;

        public Basket(BasketItems items, Guid id)
        {
            this.items = items;
            this.id = id;
        }

        public void AddItem(Product product)
        {
            this.items.Add(product);
            DomainEvents.Raise(new ProductAddedToBasket(this.id, this.items.GetItemIds()));
        }
    }

    public class ProductAddedToBasket : IDomainEvent
    {
        public Guid BasketId;
        public IEnumerable<Guid> Items;
 
        public ProductAddedToBasket(Guid basketId, IEnumerable<Guid> enumerable)
        {
            this.BasketId = basketId;
            this.Items = enumerable;
        }
    }
}