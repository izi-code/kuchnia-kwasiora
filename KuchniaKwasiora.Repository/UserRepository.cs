using KuchniaKwasiora.Database;
using KuchniaKwasiora.Domain.Interfaces;
using KuchniaKwasiora.Domain.Models;
using KuchniaKwasiora.Domain.ValueObjects;

namespace KuchniaKwasiora.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public long Create(string firstName, string lastName, Email email)
        {
            var user = new User(firstName, lastName, email);

            _dbContext.Add(user);
            _dbContext.SaveChanges();

            return user.Id;
        }
    }
}
