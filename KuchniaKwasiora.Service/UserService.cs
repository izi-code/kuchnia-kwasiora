using CSharpFunctionalExtensions;
using KuchniaKwasiora.Domain.DTOs;
using KuchniaKwasiora.Domain.Interfaces;
using KuchniaKwasiora.Domain.Models;
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

        public Result<long> Create(UserDto userDto)
        {
            if (string.IsNullOrEmpty(userDto.FirstName))
                return Result.Failure<long>("User's first name can not be empty");

            var email = Email.Create(userDto.Email);
            if (email.IsFailure)
                return Result.Fail<long>($"Email {userDto.Email} is invalid");

            var isEmailUnique = _userRepository.IsUnique(email.Value);
            if (!isEmailUnique)
                return Result.Fail<long>($"Email {userDto.Email} alredy used");

            var user = new User(userDto.FirstName, userDto.LastName, email.Value);
            var dbUserId = _userRepository.Create(user);

            return Result.Success(dbUserId);
        }
    }
}
