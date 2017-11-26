using IAWeb.Shared.Commands;

namespace IAWeb.Domain.Commands.Results
{
    public class GetCustomerCommandResult : ICommandResult
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AccessLevel { get; set; }
    }
}
