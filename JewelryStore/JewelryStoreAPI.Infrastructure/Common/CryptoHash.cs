using System.Security.Cryptography;

namespace JewelryStoreAPI.Infrastructure.Common
{
    public class CryptoHash
    {
        public int SaltLength { get; set; } = 16;

        public byte[] GetRandomSalt()
        {
            using RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();

            var randomSalt = new byte[SaltLength];

            rngCsp.GetNonZeroBytes(randomSalt);

            return randomSalt;
        }

        public byte[] ComputeHash(byte[] input, byte[] salt)
        {
            using SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();

            var inputAndSaltBytes = new byte[input.Length + salt.Length];

            input.CopyTo(inputAndSaltBytes, 0);
            salt.CopyTo(inputAndSaltBytes, input.Length);

            return sha256.ComputeHash(inputAndSaltBytes);
        }
    }
}
