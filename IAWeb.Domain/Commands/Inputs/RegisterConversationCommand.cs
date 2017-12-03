using IAWeb.Shared.Commands;

namespace IAWeb.Domain.Commands.Inputs
{
    public class RegisterConversationCommand : ICommand
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
