namespace cl1TimePad
{
    public class OTPEncrypter
    {
        public List<byte> Encrypt(List<byte> plainData, List<byte> key)
        {
            List<byte> cipherText = new List<byte>();
            if (plainData.Count > key.Count)
            {
                throw new Exception("Key can not be shorter than data");
            }
            for (int i = 0; i < plainData.Count; i++)
            {
                cipherText.Add((byte)(plainData[i] ^ key[i]));
            }
            return cipherText;
        }

        public List<byte> Decrypt(List<byte> cipherData, List<byte> key)
        {
            return Encrypt(cipherData, key);
        }
    }
}