using CSharpFunctionalExtensions;
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

        public Result<long> Create(PostDto post)
        {
            if (string.IsNullOrWhiteSpace(post.Email))
            {
                return Result.Failure<long>("Can not create a post without an Author");
            }

            var userEmail = Email.Create(post.Email).Value;
            var user = _userRepository.GetUserByEmail(userEmail);
            if (user == null)
            {
                return Result.Failure<long>($"User with {userEmail.Value} email not found");
            }

            var dbPostId = _postRepository.Create(new Post(post.Content, user));
            return Result.Success(dbPostId);
        }
    }
}
