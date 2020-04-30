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

        public long Create(UserDto user)
        {
            if (string.IsNullOrEmpty(user.FirstName))
                return -1;

            var email = Email.Create(user.Email);
            if (email.IsFailure)
                return -1;

            return _userRepository.Create(user.FirstName, user.LastName, email.Value);
        }
    }
}
