using System;
using System.Collections.Generic;

namespace DDDConcepts
{
    public class Product
    {
        private Guid id;
        private Price sellingPrice;
        private Price retailPrice;
        private List<Option> options;

        public Product(Guid id, Price sellingPrice, Price retailPrice, List<Option> options)
        {
            if (sellingPrice.Matches(retailPrice) == false)
                 throw new Exception("Selling and retail price must be in the same currency");            
            this.id = id;
            this.sellingPrice = sellingPrice;
            this.retailPrice = retailPrice;
            this.options = options;
        }

        public void ChangePriceTo(Price newPrice)
        {
            if (this.sellingPrice.Matches(newPrice) == false)
                throw new Exception("Cannot change the price of this product to a different currency");
            this.sellingPrice = newPrice;
        }

        public Price CalculateSavings()
        {
            Price savings = this.retailPrice.Minus(this.sellingPrice);
            if (savings.IsGreaterThanZero())
                return savings;
            else 
                return new Price(0, this.retailPrice.Currency);
        }

        public void AddOption(Option option) 
        {
            if (this.options.Contains(option))
                throw new ProductAddedOptionNotUnique(this, option);
            this.options.Add(option);
        }
    }
}