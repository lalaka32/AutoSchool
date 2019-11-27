using AutoMapper;
using DataService.Services.Interfaces;

namespace DataService.Mapper.Converters
{
    public class EncryptionConverter : IValueConverter<byte[], string>, IValueConverter<string, byte[]>
    {
        private readonly ICurrentUserEncryptionService _encryptionService;

        public EncryptionConverter(ICurrentUserEncryptionService encryptionService)
        {
            _encryptionService = encryptionService;
        }

        public string Convert(byte[] sourceMember, ResolutionContext context)
        {
            return _encryptionService.Decrypt(sourceMember);
        }

        public byte[] Convert(string sourceMember, ResolutionContext context)
        {
            return _encryptionService.Encrypt(sourceMember);
        }
    }
}