using KuchniaKwasiora.Domain.DTOs;

namespace KuchniaKwasiora.Domain.Interfaces
{
    public interface IUserService
    {
        long Create(UserDto user);
    }
}
