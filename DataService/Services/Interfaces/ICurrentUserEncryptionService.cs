namespace DataService.Services.Interfaces
{
    public interface ICurrentUserEncryptionService
    {
        byte[] Encrypt(string value);

        string Decrypt(byte[] encrypted);
    }
}