using IAWeb.Domain.ValueObjects;
using IAWeb.Shared.Entities;
using System.Collections.Generic;

namespace IAWeb.Domain.Entities
{
    public class Customer : Entity
    {
        protected Customer() { }

        public Customer(Name name, Document document, User user, Email email)
        {
            Name = name;
            Email = email;
            Document = document;
            User = user;
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public User User { get; private set; }
        public Email Email { get; private set; }

    }
}
