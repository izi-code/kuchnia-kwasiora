using KuchniaKwasiora.Database;
using KuchniaKwasiora.Domain.Interfaces;
using KuchniaKwasiora.Domain.Models;

namespace KuchniaKwasiora.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext _dbContext;

        public PostRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public long Create(Post post)
        {
            _dbContext.Add(post);
            _dbContext.SaveChanges();

            return post.Id;
        }
    }
}
