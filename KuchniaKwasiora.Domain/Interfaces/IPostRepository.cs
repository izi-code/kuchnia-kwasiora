using KuchniaKwasiora.Domain.Models;

namespace KuchniaKwasiora.Domain.Interfaces
{
    public interface IPostRepository
    {
        long Create(Post post);
    }
}
