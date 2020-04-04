using System;
using System.Threading.Tasks;
using Actio.Common.Exceptions;
using Actio.Services.Identity.Domain.Models;
using Actio.Services.Identity.Domain.Repositories;
using Actio.Services.Identity.Domain.Services;

namespace Actio.Services.Identity.Services
{
    class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;

        public UserService(IUserRepository userRepository, IEncrypter encrypter)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
        }

        public async Task RegisterAsync(string email, string password, string name)
        {
            var user = await _userRepository.GetAsync(email);
            if (user != null) throw new ActioException("email_taken", $"Email {email} is already taken");
            user = new User(email, name);
            user.SetPassword(password, _encrypter);
            await _userRepository.AddAsync(user);
        }

        public async Task LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user == null) throw new ActioException("invalid_credentials", $"Invalid user credentials");
            if (!user.ValidatePassword(password, _encrypter)) throw new ActioException("invalid_credentials",
                $"Invalid user credentials");
        }
    }
}