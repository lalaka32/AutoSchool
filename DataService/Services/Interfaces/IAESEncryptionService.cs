using Common.DataContracts.User;

namespace DataService.Services.Interfaces
{
    public interface IAesEncryptionService
    {
        byte[] Encrypt(string value, byte[] key, byte[] IV);

        string Decrypt(byte[] encrypted, byte[] key, byte[] IV);
        
        EncryptionData GenerateKey();
    }
}