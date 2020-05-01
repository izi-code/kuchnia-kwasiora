using KuchniaKwasiora.Domain.DTOs;

namespace KuchniaKwasiora.Domain.Interfaces
{
    public interface IPostService
    {
        long Create(PostDto post);
    }
}
