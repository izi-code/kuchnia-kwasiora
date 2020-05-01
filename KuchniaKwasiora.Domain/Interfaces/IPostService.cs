using CSharpFunctionalExtensions;
using KuchniaKwasiora.Domain.DTOs;

namespace KuchniaKwasiora.Domain.Interfaces
{
    public interface IPostService
    {
        Result<long> Create(PostDto post);
    }
}
