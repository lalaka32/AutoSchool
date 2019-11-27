using Common.DataContracts.User;
using DataAccess.Interfaces;
using DataService.Services.Interfaces;

namespace DataService.Services.Implementations
{
    public class EncryptionService : IEncryptionService
    {
        private readonly IAesEncryptionService _aesEncryptionService;

        public EncryptionService(IAesEncryptionService aesEncryptionService)
        {
            _aesEncryptionService = aesEncryptionService;
        }

        public byte[] Encrypt(string value, byte[] key, byte[] IV)
        {
            return _aesEncryptionService.Encrypt(value, key, IV);
        }

        public string Decrypt(byte[] encrypted, byte[] key, byte[] IV)
        {
            return _aesEncryptionService.Decrypt(encrypted, key, IV);
        }

        public EncryptionData GenerateKey()
        {
            return _aesEncryptionService.GenerateKey();
        }
    }
}