using KuchniaKwasiora.Database;
using KuchniaKwasiora.Domain.Interfaces;
using KuchniaKwasiora.Domain.Models;
using KuchniaKwasiora.Domain.ValueObjects;
using System.Collections.Immutable;
using System.Linq;

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

        public User GetUserByEmail(Email email)
        {
            return _dbContext.Users.SingleOrDefault(x => x.Email == email);
        }

        public bool IsUnique(Email email)
        {
            var dbResult = _dbContext.Users.Where(x => x.Email == email);

            return dbResult.ToImmutableList().Count > 0 ? true : false;
        }
    }
}
