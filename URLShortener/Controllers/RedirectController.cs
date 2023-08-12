using Microsoft.AspNetCore.Mvc;
using SharedUrlShortenerData;
using System.Net;

namespace URLShortener.Controllers
{
    [ApiController]
    public class UrlShortenerController : ControllerBase
    {
        private List<UrlData> urlData = new List<UrlData>();
        public UrlShortenerController()
        {
            urlData.Add(new UrlData
            {
                Key = "rickroll",
                LongUrl = "https://www.youtube.com/watch?v=dQw4w9WgXcQ&pp=ygUXbmV2ZXIgZ29ubmEgZ2l2ZSB5b3UgdXA%3D"
            });
        }

        [HttpGet("{key}")]
        public ActionResult Get(string key)
        {
            var longUrl = urlData.FirstOrDefault(x => x.Key == key)?.LongUrl;

            if (longUrl is null)
            {
                return NotFound("Invalid URL");
            }

            return Redirect(longUrl);
        }
    }
}
