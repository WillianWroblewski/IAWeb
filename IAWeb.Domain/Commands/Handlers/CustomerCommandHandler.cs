using IAWeb.Domain.Commands.Inputs;
using IAWeb.Shared.Commands;
using IAWeb.Domain.Repositories;
using IAWeb.Domain.ValueObjects;
using IAWeb.Domain.Entities;
using IAWeb.Domain.Commands.Results;

namespace IAWeb.Domain.Commands.Handlers
{
    public class CustomerCommandHandler : ICommandHandler<RegisterCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public ICommandResult Handle(RegisterCustomerCommand command)
        {
            // Passo 1. Verificar se o CPF já existe
            if (_customerRepository.DocumentExists(command.Document))
            {
                return null;
            }

            // Passo 2. Gerar o novo cliente
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var user = new User(command.Username, command.Password, command.ConfirmPassword, Enums.AccessLevel.AccessUser);
            var customer = new Customer(name, document, user, email);

            // Passo 3. Inserir no banco
            _customerRepository.Save(customer);
            
            // Passo 4. Retornar algo
            return new RegisterCustomerCommandResult(customer.Id, customer.Name.ToString());

        }
    }
}
