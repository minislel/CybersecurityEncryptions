using System;
using System.Security.Cryptography;
using System.Text;

namespace CybersecurityEncryptions.Models
{
	public class RSACipher : ICipher
	{
		public static string[] GenerateKeyPair()
		{
			using (RSA rsa = RSA.Create(2048))
			{
				string privateKey = Convert.ToBase64String(rsa.ExportRSAPrivateKey());
				string publicKey = Convert.ToBase64String(rsa.ExportRSAPublicKey());
				return new string[] { privateKey, publicKey };
			}
		}
		public static string DecryptMessage(string message, string privateKey)
		{
			using (RSA rsa = RSA.Create())
			{
				byte[] privateKeyBytes = Convert.FromBase64String(privateKey);
				rsa.ImportRSAPrivateKey(privateKeyBytes, out _);

				byte[] messageBytes = Convert.FromBase64String(message);
				byte[] decryptedBytes = rsa.Decrypt(messageBytes, RSAEncryptionPadding.OaepSHA256);

				return Encoding.UTF8.GetString(decryptedBytes);
			}
		}
		public static string EncryptMessage(string message, string publicKey)
		{
			using (RSA rsa = RSA.Create())
			{
				byte[] publicKeyBytes = Convert.FromBase64String(publicKey);
				rsa.ImportRSAPublicKey(publicKeyBytes, out _);

				byte[] messageBytes = Encoding.UTF8.GetBytes(message);
				byte[] encryptedBytes = rsa.Encrypt(messageBytes, RSAEncryptionPadding.OaepSHA256);

				return Convert.ToBase64String(encryptedBytes);
			}
		}
	}
}
