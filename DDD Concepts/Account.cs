// http://blog.sapiensworks.com/post/2016/07/14/DDD-Aggregate-Decoded-1
using System;

namespace DDDConcepts {
    public class TransferNumber {
        public string Value {get;}
        public Guid EntityId {get;}
    }

    public class AccountNumber {
        public string Number {get;}
        public AccountNumber(string number) {
            this.Number = number;
        }

        public override bool Equals(object obj){
            if ((obj == null) || (obj is AccountNumber == false)) return false;
            var otherNumber = obj as AccountNumber;
            return this.Number.Equals(otherNumber.Number);
        }
    }

    public class BookkeepingEntry {
        public decimal Value {get;}
        public AccountNumber Account {get;}
        public BookkeepingEntry (decimal value, AccountNumber account) {
            if (value <= 0) throw new InvalidOperationException("Can not perform a money transfer with a negative value");
            if (account == null) throw new InvalidOperationException("Money transfer can not be performed on an invalid account");
            this.Value = value;
            this.Account = account;
        }
    }
}