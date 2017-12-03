
using IAWeb.Shared.Entities;

namespace IAWeb.Domain.Entities
{
    public class Conversation : Entity
    {
        private Conversation() { }

        public Conversation(string question, string answer)
        {
            Question = question;
            Answer = answer;
        }

        public string Question { get; private set; }
        public string Answer { get; private set; }
    }
}
