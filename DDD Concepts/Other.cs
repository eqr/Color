// Only utility stuff, not consider as a good example
using System;

namespace DDDConcepts
{
    public class Price
    {
        private readonly Money money;

        public Currency Currency
        {
            get
            {
                return this.money.Currency;
            }
        }

        public decimal Amount
        {
            get
            {
                return this.money.Amount;
            }
        }

        public Money Money { get { return this.money; } }
        public Price(decimal amount, Currency currency)
        {
            this.money = new Money(amount, currency);
        }

        public Price(Money money)
        {
            this.money = money;
        }

        public bool Matches(Price otherPrice)
        {
            return this.Currency.Equals(otherPrice.Currency);
        }

        public Price Minus(Price otherPrice)
        {
            // TODO check if currencies match, throw exception if not
            // TODO check amounts to see that substraction is valid
            return new Price(this.money.Substract(otherPrice.Money));
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

    public class Currency
    {
        public Currency(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
    }

    internal class NonMatchingCurrencyException : Exception
    {
        private Money money;
        private Money moneyToAdd;

        public NonMatchingCurrencyException()
        {
        }

        public NonMatchingCurrencyException(string message) : base(message)
        {
        }

        public NonMatchingCurrencyException(Money money, Money moneyToAdd)
        {
            this.money = money;
            this.moneyToAdd = moneyToAdd;
        }

        public NonMatchingCurrencyException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    internal class CanNotRemoveMoreMoneyThanHaveException : Exception
    {
        private Money money;
        private Money moneyToRemove;

        public CanNotRemoveMoreMoneyThanHaveException()
        {
        }

        public CanNotRemoveMoreMoneyThanHaveException(string message) : base(message)
        {
        }

        public CanNotRemoveMoreMoneyThanHaveException(Money money, Money moneyToRemove)
        {
            this.money = money;
            this.moneyToRemove = moneyToRemove;
        }

        public CanNotRemoveMoreMoneyThanHaveException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class Consignment
    {
        internal object ConsignmentWeight()
        {
            throw new NotImplementedException();
        }
    }

    public class WeightInKg
    {
        private decimal v;

        public WeightInKg(decimal v)
        {
            this.v = v;
        }

        internal WeightInKg Add(object p)
        {
            throw new NotImplementedException();
        }
    }

    public class WeightBand
    {
        public Lazy<object> ForConsignmentsUpToThisWeightInKg { get; internal set; }
        public Money Price { get; internal set; }

        internal bool IsWithinBand(WeightInKg weight)
        {
            throw new NotImplementedException();
        }
    }
}