using KuchniaKwasiora.Domain.Common;

namespace KuchniaKwasiora.Domain.Models
{
    public class Post : BaseModel
    {
        public string Content { get; set; }
        public virtual User User { get; set; }

        protected Post()
        {
        }

        public Post(string content, User user)
        {
            Content = content;
            User = user;
        }
    }
}
