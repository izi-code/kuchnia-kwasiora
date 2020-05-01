using KuchniaKwasiora.Domain.DTOs;
using KuchniaKwasiora.Domain.Interfaces;
using KuchniaKwasiora.Domain.Models;
using KuchniaKwasiora.Domain.ValueObjects;

namespace KuchniaKwasiora.Service
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;

        public PostService(IPostRepository postRepository, IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        public long Create(PostDto post)
        {
            var userEmail = Email.Create(post.Email).Value;
            var user = _userRepository.GetUserByEmail(userEmail);
            if (user == null)
            {
                return -1;
            }

            return _postRepository.Create(new Post(post.Content, user));
        }
    }
}
