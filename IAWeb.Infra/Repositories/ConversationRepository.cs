using System;
using System.Collections.Generic;
using IAWeb.Domain.Entities;
using IAWeb.Domain.Repositories;
using IAWeb.Infra.Contexts;
using System.Linq;
using System.Data.Entity;

namespace IAWeb.Infra.Repositories
{
    public class ConversationRepository : IConversationRepository
    {
        private readonly IAWebDataContext _context;

        public ConversationRepository(IAWebDataContext context)
        {
            _context = context;
        }

        public Conversation Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Conversation> GetAll()
        {
            return _context.Conversations.ToList();
        }

        public Conversation GetByAnswer(string answer)
        {
            throw new NotImplementedException();
        }

        public Conversation GetByQuestion(string question)
        {
            throw new NotImplementedException();
        }

        public void Save(Conversation conversation)
        {
            _context.Conversations.Add(conversation);
        }

        public void Update(Conversation conversation)
        {
            _context.Entry(conversation).State = EntityState.Modified;
        }
    }
}
