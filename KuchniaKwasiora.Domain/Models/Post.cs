using KuchniaKwasiora.Domain.Common;

namespace KuchniaKwasiora.Domain.Models
{
    public class Post : Entity
    {
        public string Content { get; private set; }
        public virtual User User { get; private set; }

        protected Post()
        {
        }

        public Post(string content, User user) : this()
        {
            Content = content;
            User = user;
        }
    }
}
