namespace Common.DataContracts.User
{
    public class EncryptionData
    {
        public byte[] Key { get; set; }

        public byte[] IV { get; set; }
    }
}