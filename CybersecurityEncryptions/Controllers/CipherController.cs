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
        public IActionResult Caesar([FromForm] CaesarCipher model)
        {
            return View("~/Views/Ciphers/Caesar.cshtml", model);
        }
        public IActionResult Polybius([FromForm] PolybiusSquare model)
        {
            if(model.Key is not null)
            {
				model.Key = model.Key.ToUpper();
			}
            
			return View("~/Views/Ciphers/Polybius.cshtml", model);
		}

    }
}
