using IAWeb.Domain.Enums;
using IAWeb.Shared.Entities;

namespace IAWeb.Domain.Entities
{
    public class User : Entity
    {
        protected User() { }

        public User(string username, string passworld, string confirmPassword, AccessLevel accessLevel)
        {
            Username = username;
            Password = passworld;
            AccessLevel = accessLevel;
        }

        public string Username { get; private set; }
        public string Password { get; private set; }
        public AccessLevel AccessLevel { get; private set; }
    }
}
