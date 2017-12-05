using System;
using System.Collections.Generic;

namespace DDDConcepts
{
    public partial class Client
    {
        private readonly List<Order> orders = new List<Order>();
        
        public Account Account { get; protected set; }
        public Client(Account account)
        {
            if (account == null)
                throw new ArgumentNullException("account");

            Account = account;
            Account.AddRole(Role.Client);
        }
    }
}