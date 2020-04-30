using KuchniaKwasiora.Domain.ValueObjects;

namespace KuchniaKwasiora.Domain.Interfaces
{
    public interface IUserRepository
    {
        long Create(string firstName, string lastName, Email email);
    }
}
