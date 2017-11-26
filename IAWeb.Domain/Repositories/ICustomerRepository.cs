using System;
using IAWeb.Domain.Entities;
using IAWeb.Domain.Commands.Results;
using System.Collections.Generic;

namespace IAWeb.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer Get(Guid id);
        Customer GetByUsername(string username);
        List<Customer> GetAll();
        GetCustomerCommandResult Get(string username);
        void Save(Customer customer);
        void Update(Customer customer);
        bool DocumentExists(string document);
    }
}
