using IAWeb.Shared.Commands;

namespace IAWeb.Domain.Commands.Results
{
    public class GetConversationCommandResult : ICommandResult
    {
        public string Qusetion { get; set; }
        public string Answer { get; set; }
    }
}
