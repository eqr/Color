using System;

namespace DDDConcepts
{
    public class Money
    {
        public decimal Amount { get; private set; }
        public Currency Currency { get; private set; }

        public Money() : this(0, new Currency("Sterling")) { }
        public Money(decimal amount, Currency currency)
        {
            this.Amount = amount;
            this.Currency = currency;
        }

        public Money Add(Money moneyToAdd)
        {
            if (this.Currency.Equals(moneyToAdd.Currency) == false)
                throw new NonMatchingCurrencyException(this, moneyToAdd);
            return new Money(this.Amount + moneyToAdd.Amount, this.Currency);
        }

        public Money Remove(Money moneyToRemove)
        {
            if (this.Currency.Equals(moneyToRemove.Currency) == false)
                throw new NonMatchingCurrencyException(this, moneyToRemove);
            if (this.Amount < moneyToRemove.Amount)
                throw new CanNotRemoveMoreMoneyThanHaveException(this, moneyToRemove);
            return new Money(this.Amount - moneyToRemove.Amount, this.Currency);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return this.Amount.GetHashCode() + this.Currency.GetHashCode();
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null) 
                return false;
            Money otherMoney = obj as Money;
            if (otherMoney == null) 
                return false;
            return this.Currency.Equals(otherMoney.Currency) && this.Amount == otherMoney.Amount;
        }
    }
}