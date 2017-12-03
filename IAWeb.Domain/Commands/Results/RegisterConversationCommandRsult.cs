using IAWeb.Shared.Commands;
using System;

namespace IAWeb.Domain.Commands.Results
{
    public class RegisterConversationCommandRsult : ICommandResult
    {
        public RegisterConversationCommandRsult()
        {

        }
        public RegisterConversationCommandRsult(Guid id, string question)
        {
            Id = id;
            Question = question;
        }

        public Guid Id { get; set; }
        public string Question { get; set; }
    }
}
