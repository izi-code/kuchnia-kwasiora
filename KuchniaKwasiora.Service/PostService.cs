using CSharpFunctionalExtensions;
using KuchniaKwasiora.Domain.DTOs;
using KuchniaKwasiora.Domain.Interfaces;
using KuchniaKwasiora.Domain.Models;

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

        public Result<long> Create(PostDto postDto)
        {
            if (string.IsNullOrWhiteSpace(postDto.Email))
                return Result.Failure<long>("Can not create a post without an Author");

            var user = _userRepository.Get(postDto.UserId);
            if (user == null)
                return Result.Failure<long>($"User does not exist");

            var post = new Post(postDto.Content, user);
            var dbPostId = _postRepository.Create(post);

            return Result.Success(dbPostId);
        }
    }
}
