﻿using CybersecurityEncryptions.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;

namespace CybersecurityEncryptions.Controllers
{
    public class CipherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Caesar()
        {
            return View("~/Views/Ciphers/Caesar.cshtml");
        }
        public IActionResult CaesarEncrypt(string message, int? key)
        {
            if (key is null || string.IsNullOrEmpty(message))
            {
				ViewBag.ErrorMessage = "Please provide a message and a key";
				return View("~/Views/Ciphers/Caesar.cshtml");
			}
			ViewBag.EncryptedMessage = CaesarCipher.EncryptMessage(message, (int)key); 
			return View("~/Views/Ciphers/Caesar.cshtml");
		}
        public IActionResult CaesarDecrypt(string message, int? key)
        {
            if (key is null || string.IsNullOrEmpty(message))
            {
                ViewBag.ErrorMessage = "Please provide a message and a key";
                return View("~/Views/Ciphers/Caesar.cshtml");
            }
            ViewBag.DecryptedMessage = CaesarCipher.DecryptMessage(message, (int)key);
            return View("~/Views/Ciphers/Caesar.cshtml");
        }

        public IActionResult Polybius()
        {
			return View("~/Views/Ciphers/Polybius.cshtml");
		}
        public IActionResult PolybiusEncrypt(string message)
        {
			if (string.IsNullOrEmpty(message))
            {
				ViewBag.ErrorMessage = "Please provide a message";
				return View("~/Views/Ciphers/Polybius.cshtml");
			}
			ViewBag.EncryptedMessage = PolybiusSquare.EncryptMessage(message);
			return View("~/Views/Ciphers/Polybius.cshtml");
		}
		public IActionResult PolybiusDecrypt(string message)
		{
            if (string.IsNullOrEmpty(message))
            {
                ViewBag.ErrorMessage = "Please provide a message";
                return View("~/Views/Ciphers/Polybius.cshtml");
            }
            ViewBag.DecryptedMessage = PolybiusSquare.DecryptMessage(message);
            return View("~/Views/Ciphers/Polybius.cshtml");
        }

		public IActionResult Vignere()
		{
			return View("~/Views/Ciphers/Vignere.cshtml");
		}
		public IActionResult VignereEncrypt(string message, string key)
		{
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(message))
            {
                ViewBag.ErrorMessage = "Please provide a message and a key";
                return View("~/Views/Ciphers/Vignere.cshtml");
            }
            ViewBag.EncryptedMessage = VignereCipher.EncryptMessage(message, key);
			return View("~/Views/Ciphers/Vignere.cshtml");
		}
		public IActionResult VignereDecrypt(string message, string key)
		{
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(message))
            {
                ViewBag.ErrorMessage = "Please provide a message and a key";
                return View("~/Views/Ciphers/Vignere.cshtml");
            }
            ViewBag.DecryptedMessage = VignereCipher.DecryptMessage(message, key);
			return View("~/Views/Ciphers/Vignere.cshtml");
		}

		public IActionResult Playfair()
		{
			return View("~/Views/Ciphers/Playfair.cshtml");
		}
		public IActionResult PlayfairEncrypt(string message, string key)
		{
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(message))
            {
                ViewBag.ErrorMessage = "Please provide a message and a key";
                return View("~/Views/Ciphers/Playfair.cshtml");
            }
            ViewBag.EncryptedMessage = PlayfairCipher.EncryptMessage(message, key);
			return View("~/Views/Ciphers/Playfair.cshtml");
		}
		public IActionResult PlayfairDecrypt(string message, string key)
		{
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(message))
            {
                ViewBag.ErrorMessage = "Please provide a message and a key";
                return View("~/Views/Ciphers/Playfair.cshtml");
            }
            ViewBag.DecryptedMessage = PlayfairCipher.DecryptMessage(message, key);
            return View("~/Views/Ciphers/Playfair.cshtml");
		}
        public IActionResult RSA()
        {
            return View("~/Views/Ciphers/RSA.cshtml");
        }
        public IActionResult RSAEncrypt(string message, string key)
        {
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(message))
            {
                ViewBag.ErrorMessage = "Please provide a message and a key";
                return View("~/Views/Ciphers/RSA.cshtml");
            }
            try
            {
				ViewBag.EncryptedMessage = RSACipher.EncryptMessage(message, key);
			}
            catch
            {
				ViewBag.ErrorMessage = "The key was in an incorrect format";
				return View("~/Views/Ciphers/RSA.cshtml");
			}
            return View("~/Views/Ciphers/RSA.cshtml");
        }
        public IActionResult RSADecrypt(string message, string key)
        {
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(message))
            {
                ViewBag.ErrorMessage = "Please provide a message and a key";
                return View("~/Views/Ciphers/RSA.cshtml");
			}
            try
            {
				ViewBag.DecryptedMessage = RSACipher.DecryptMessage(message, key);
			}
            catch
            {
				ViewBag.ErrorMessage = "The decryption was unsuccessful. Check if you're using the correct private key and if the message is in Base64 encoded format";
				return View("~/Views/Ciphers/RSA.cshtml");
			}

            return View("~/Views/Ciphers/RSA.cshtml");
        }
        public IActionResult RSAGenerateKeyPair()
        {
            string[] keys = RSACipher.GenerateKeyPair();
            ViewBag.PrivateKey = keys[0];
            ViewBag.PublicKey = keys[1];
            return View("~/Views/Ciphers/RSA.cshtml");
        }
    }
}
