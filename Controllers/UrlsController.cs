using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Services;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlsController : ControllerBase
    {
        private readonly IUrlService _urlService;

        public UrlsController(IUrlService urlService)
        {
            _urlService = urlService;
        }

        [HttpPost]
        //[Authorize]
        [AllowAnonymous]
        public IActionResult Create([FromBody] UrlCreateRequest request)
        {
           
            var url = _urlService.CreateShortUrl(request.OriginalUrl, request.CreatedBy);
            return Ok(url);
        }

        [HttpGet("{id}")]
        //[Authorize]
        [AllowAnonymous]

        public IActionResult Get(int id)
        {
            var url = _urlService.GetUrlById(id);
            if (url == null)
            {
                return NotFound();
            }
            return Ok(url);
        }

        [HttpGet]
        [AllowAnonymous]
        //[Authorize]
        public IActionResult GetAll()
        {
            var urls = _urlService.GetAllUrls();
            return Ok(urls);
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        //[Authorize]
        public IActionResult Delete(int id)
        {
            _urlService.DeleteUrl(id);
            return NoContent();
        }
    }

    public class UrlCreateRequest
    {
        public string OriginalUrl { get; set; }
        public string CreatedBy { get; set; }
    }
}
