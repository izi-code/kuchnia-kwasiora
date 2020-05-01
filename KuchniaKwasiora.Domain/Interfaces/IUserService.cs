using CSharpFunctionalExtensions;
using KuchniaKwasiora.Domain.DTOs;

namespace KuchniaKwasiora.Domain.Interfaces
{
    public interface IUserService
    {
        Result<long> Create(UserDto user);
    }
}
