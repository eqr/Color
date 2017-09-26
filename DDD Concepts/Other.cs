// Only utility stuff, not consider as a good example
using System;

namespace DDDConcepts
{
    public class Price
    {
        public string Currency { get; set; }

        public int Amount { get; set; }

        public Price(int amount, string currency)
        {
            this.Amount = amount;
            this.Currency = currency;
        }

        public bool Matches(Price otherPrice)
        {
            return this.Currency.Equals(otherPrice.Currency);
        }

        public Price Minus(Price otherPrice) 
        {
            // TODO check if currencies match, throw exception if not
            // TODO check amounts to see that substraction is valid
            return new Price(this.Amount - otherPrice.Amount, this.Currency);
        }

        public bool IsGreaterThanZero() 
        {
            return this.Amount > 0;
        }

    }

    public class ProductAddedOptionNotUnique : Exception 
    {
        private readonly Product product;
        private readonly Option option;

        public ProductAddedOptionNotUnique(Product product, Option option) 
        {
            this.product = product;
            this.option = option;
        }
    }

    public class Option
    {

    }
}