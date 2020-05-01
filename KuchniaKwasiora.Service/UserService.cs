using CSharpFunctionalExtensions;
using KuchniaKwasiora.Domain.DTOs;
using KuchniaKwasiora.Domain.Interfaces;
using KuchniaKwasiora.Domain.ValueObjects;

namespace KuchniaKwasiora.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Result<long> Create(UserDto user)
        {
            if (string.IsNullOrEmpty(user.FirstName))
                return Result.Failure<long>("User's first name can not be empty");

            var email = Email.Create(user.Email);
            if (email.IsFailure)
                return Result.Fail<long>($"Email {user.Email} is invalid");

            var isEmailUnique = _userRepository.IsUnique(email.Value);
            if (!isEmailUnique)
                return Result.Fail<long>($"Email {user.Email} alredy used");

            var dbUserId = _userRepository.Create(user.FirstName, user.LastName, email.Value);
            return Result.Success(dbUserId);
        }
    }
}
