using IAWeb.Domain.Entities;
using System;
using System.Collections.Generic;

namespace IAWeb.Domain.Repositories
{
    public interface IConversationRepository
    {
        Conversation Get(Guid id);
        Conversation GetByQuestion(string question);
        Conversation GetByAnswer(string answer);
        List<Conversation> GetAll();
        void Save(Conversation conversation);
        void Update(Conversation conversation);
    }
}
