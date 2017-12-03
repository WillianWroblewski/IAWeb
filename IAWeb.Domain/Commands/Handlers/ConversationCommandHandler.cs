using IAWeb.Domain.Commands.Inputs;
using IAWeb.Domain.Commands.Results;
using IAWeb.Domain.Entities;
using IAWeb.Domain.Repositories;
using IAWeb.Shared.Commands;

namespace IAWeb.Domain.Commands.Handlers
{
    public class ConversationCommandHandler : ICommandHandler<RegisterConversationCommand>
    {
        private readonly IConversationRepository _conversationRepository;

        public ConversationCommandHandler(IConversationRepository conversationRepository)
        {
            _conversationRepository = conversationRepository;
        }

        public ICommandResult Handle(RegisterConversationCommand command)
        {
            var question = command.Question;
            var answer = command.Answer;
            var conversation = new Conversation(question, answer);

            _conversationRepository.Save(conversation);

            return new RegisterConversationCommandRsult(conversation.Id, conversation.Question.ToString());
        }
    }
}
