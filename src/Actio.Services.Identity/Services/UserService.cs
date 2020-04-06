using System.Threading.Tasks;
using Actio.Common.Auth;
using Actio.Common.Exceptions;
using Actio.Services.Identity.Domain.Models;
using Actio.Services.Identity.Domain.Repositories;
using Actio.Services.Identity.Domain.Services;

namespace Actio.Services.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly IEncrypter _encrypter;
        private readonly IJwtHandler _jwtHandler;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IEncrypter encrypter, IJwtHandler jwtHandler)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
            _jwtHandler = jwtHandler;
        }

        public async Task RegisterAsync(string email, string password, string name)
        {
            var user = await _userRepository.GetAsync(email);
            if (user != null) throw new ActioException("email_taken", $"Email {email} is already taken");
            user = new User(email, name);
            user.SetPassword(password, _encrypter);
            await _userRepository.AddAsync(user);
        }

        public async Task<JsonWebToken> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user == null) throw new ActioException("invalid_credentials", "Invalid user credentials");
            if (!user.ValidatePassword(password, _encrypter))
                throw new ActioException("invalid_credentials",
                    "Invalid user credentials");
            return _jwtHandler.Crete(user.Id);
        }
    }
}