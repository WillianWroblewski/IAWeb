using System;
using IAWeb.Domain.Commands.Results;
using IAWeb.Domain.Entities;
using IAWeb.Domain.Repositories;
using IAWeb.Infra.Contexts;
using System.Linq;
using System.Data.Entity;
using System.Data.SqlClient;
using IAWeb.Shared;
using Dapper;
using System.Collections.Generic;

namespace IAWeb.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly IAWebDataContext _context;

        public CustomerRepository(IAWebDataContext context)
        {
            _context = context;
        }

        public bool DocumentExists(string document)
        {
            return _context.Customers.Any(x => x.Document.Number == document);
        }

        public Customer Get(Guid id)
        {
            return _context.Customers.Include(x => x.User).FirstOrDefault(x => x.Id == id);
        }

        public GetCustomerCommandResult Get(string username)
        {

            /* Método usando o Entity Freamwork */
            //return _context
            //    .Customers
            //    .Include(x => x.User)
            //    .AsNoTracking()
            //    .Select(x => new GetCustomerCommandResult
            //    {
            //        Name = x.Name.ToString(),
            //        Document = x.Document.Number,
            //        Active = x.User.Active,
            //        Email = x.Email.Address,
            //        Password = x.User.Password,
            //        Username = x.User.Username
            //    })
            //    .FirstOrDefault(x => x.Username == username);

            /* Método usando o Dapper */
            var query = "SELECT * FROM [GetCustomerInfoView] WHERE [Username]=@username";
            using (var conn = new SqlConnection(Runtime.ConnectionString))
            {
                conn.Open();
                return conn.Query<GetCustomerCommandResult>(query, new { username = username }).FirstOrDefault();
            }
        }

        public List<Customer> GetAll()
        {
            return _context.Customers.Include(x => x.User).AsNoTracking().ToList();
        }

        public Customer GetByUsername(string username)
        {
            return _context.Customers.Include(x => x.User).AsNoTracking().FirstOrDefault(x => x.User.Username == username);
        }

        public void Save(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
        }
    }
}
