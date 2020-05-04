using KuchniaKwasiora.Domain.Models;
using KuchniaKwasiora.Domain.ValueObjects;

namespace KuchniaKwasiora.Domain.Interfaces
{
    public interface IUserRepository
    {
        long Create(User user);
        User Get(long id);
        User GetUserByEmail(Email email);
        bool IsUnique(Email email);
    }
}
