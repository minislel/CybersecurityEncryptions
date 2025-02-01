using CybersecurityEncryptions.Models;
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
        public IActionResult CaesarEncrypt([FromForm] CaesarCipher model)
        {
            if (!model.IsModelValid())
            {
				ViewBag.ErrorMessage = "Please provide a message and a key";
				return View("~/Views/Ciphers/Caesar.cshtml");
			}
			ViewBag.EncryptedMessage = model.EncryptMessage(model.Message, model.Key); 
			return View("~/Views/Ciphers/Caesar.cshtml");
		}
        public IActionResult CaesarDecrypt([FromForm] CaesarCipher model)
        {
			if (!model.IsModelValid())
			{
				ViewBag.ErrorMessage = "Please provide a message and a key";
				return View("~/Views/Ciphers/Caesar.cshtml");
			}
			ViewBag.DecryptedMessage = model.DecryptMessage(model.Message, model.Key);
			return View("~/Views/Ciphers/Caesar.cshtml");
        }

        public IActionResult Polybius()
        {
			return View("~/Views/Ciphers/Polybius.cshtml");
		}
        public IActionResult PolybiusEncrypt([FromForm] PolybiusSquare model)
        {
			if (!model.IsModelValid())
            {
				ViewBag.ErrorMessage = "Please provide a message and a key";
				return View("~/Views/Ciphers/Polybius.cshtml");
			}
			ViewBag.EncryptedMessage = model.EncryptMessage(model.Message, model.Key);
			return View("~/Views/Ciphers/Polybius.cshtml");
		}
		public IActionResult PolybiusDecrypt([FromForm] PolybiusSquare model)
		{
			if (!model.IsModelValid())
			{
				ViewBag.ErrorMessage = "Please provide a message and a key";
				return View("~/Views/Ciphers/Polybius.cshtml");
			}
			ViewBag.DecryptedMessage = model.DecryptMessage(model.Message, model.Key);
			return View("~/Views/Ciphers/Polybius.cshtml");
		}

		public IActionResult Vignere()
		{
			return View("~/Views/Ciphers/Vignere.cshtml");
		}
		public IActionResult VignereEncrypt([FromForm] VignereCipher model)
		{
			if (!model.IsModelValid())
			{
				ViewBag.ErrorMessage = "Please provide a message and a key";
				return View("~/Views/Ciphers/Vignere.cshtml", model);
			}
			ViewBag.EncryptedMessage = model.EncryptMessage(model.Message, model.Key);
			return View("~/Views/Ciphers/Vignere.cshtml", model);
		}
		public IActionResult VignereDecrypt([FromForm] VignereCipher model)
		{
			if (!model.IsModelValid())
			{
				ViewBag.ErrorMessage = "Please provide a message and a key";
				return View("~/Views/Ciphers/Vignere.cshtml", model);
			}
			ViewBag.DecryptedMessage = model.DecryptMessage(model.Message, model.Key);
			return View("~/Views/Ciphers/Vignere.cshtml", model);
		}

		public IActionResult Playfair()
		{
			return View("~/Views/Ciphers/Playfair.cshtml");
		}
		public IActionResult PlayfairEncrypt([FromForm] PlayfairCipher model)
		{
			if (!model.IsModelValid())
			{
				ViewBag.ErrorMessage = "Please provide a message and a key";
				return View("~/Views/Ciphers/Playfair.cshtml", model);
			}
			ViewBag.EncryptedMessage = model.EncryptMessage(model.Message, model.Key);
			return View("~/Views/Ciphers/Playfair.cshtml", model);
		}
		public IActionResult PlayfairDecrypt([FromForm] PlayfairCipher model)
		{
			if (!model.IsModelValid())
			{
				ViewBag.ErrorMessage = "Please provide a message and a key";
				return View("~/Views/Ciphers/Playfair.cshtml", model);
			}
			ViewBag.DecryptedMessage = model.DecryptMessage(model.Message, model.Key);
			return View("~/Views/Ciphers/Playfair.cshtml", model);
		}
	}
}
