using System;
using IAWeb.Shared.Commands;

namespace IAWeb.Domain.Commands.Results
{
    public class RegisterCustomerCommandResult : ICommandResult
    {
        public RegisterCustomerCommandResult()
        {

        }
        public RegisterCustomerCommandResult(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
