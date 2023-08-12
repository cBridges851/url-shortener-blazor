using System.ComponentModel.DataAnnotations;

namespace SharedUrlShortenerData {
    public class UrlData {
        [Required]
        public string Key = "";
        [Required]
        public string LongUrl = "";
        public string ShortUrl = "";
    }
}