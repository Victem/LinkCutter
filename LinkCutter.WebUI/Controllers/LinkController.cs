
using LinkCutter.WebUI.LinkGenerator;
using LinkCutter.WebUI.Models;

using Microsoft.AspNetCore.Mvc;

namespace LinkCutter.WebUI.Controllers
{
    public class LinkController : Controller
    {
        private readonly ILinkStorage _storage;

        public LinkController(ILinkStorage storage)
        {
            _storage = storage;
        }

        [HttpPost]
        public async Task<ActionResult> Generate(LinkGenerationModel model)
        {

            var token = await _storage.GetToken(model.LinkToEncode);
            return RedirectToAction("Generated", "Link", new { encodeResult = token });
        }

        [HttpGet]
        public async Task<ActionResult> Generated(string encodeResult = null) 
        {
            var url = Url.Link("Redirection_Handler", new { url = encodeResult });
            return View(new LinkGenerationModel { EncodeResult = url });
        }

        [HttpGet("{url}", Name = "Redirection_Handler")]
        public async Task<ActionResult> GetRedirection(string url)
        {
            var originalUrl = await _storage.GetOriginalUrl(url);
            if (originalUrl is null) 
            {
                return NotFound();
            }
            
            return Redirect(originalUrl);
        }
    }
}
