using KuchniaKwasiora.Domain.Common;
using KuchniaKwasiora.Domain.ValueObjects;

namespace KuchniaKwasiora.Domain.Models
{
    public class User : BaseModel
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Email Email { get; private set; }

        protected User()
        {
        }

        public User(string firstName, string lastName, Email email) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
