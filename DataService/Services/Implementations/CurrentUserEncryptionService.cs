using DataAccess.Interfaces;
using DataService.Services.Interfaces;

namespace DataService.Services.Implementations
{
    public class CurrentUserEncryptionService : ICurrentUserEncryptionService
    {
        private readonly IAesEncryptionService _aesEncryptionService;
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationService _authenticationService;

        public CurrentUserEncryptionService(IAesEncryptionService aesEncryptionService, IUserRepository userRepository,
            IAuthenticationService authenticationService)
        {
            _aesEncryptionService = aesEncryptionService;
            _userRepository = userRepository;
            _authenticationService = authenticationService;
        }

        public byte[] Encrypt(string value)
        {
            var currentUser = _userRepository.Get(_authenticationService.GetCurrentUserId());
            return _aesEncryptionService.Encrypt(value, currentUser.Key, currentUser.IV);
        }

        public string Decrypt(byte[] encrypted)
        {
            var currentUser = _userRepository.Get(_authenticationService.GetCurrentUserId());
            return _aesEncryptionService.Decrypt(encrypted, currentUser.Key, currentUser.IV);
        }
    }
}