using Microsoft.AspNetCore.Components;
using SharedUrlShortenerData;

namespace URLShortener.Services
{
    public class DataService
    {
        private List<UrlData> urlDatas = new List<UrlData>();
        public NavigationManager navigationManager { get; }

        public DataService(NavigationManager navigationManager) {
            this.navigationManager = navigationManager;
        }

        public List<UrlData> GetAllUrlData() {
            return this.urlDatas;
        }

        public ShortenResult AddUrl(string key, string longUrl) {
            var urlDataWithKey = urlDatas.FirstOrDefault(x => x.Key == key);
            if (urlDataWithKey is not null) {
                return new ShortenResult {
                    Status = Status.KeyAlreadyExists,
                    UrlData = urlDataWithKey
                };
            }

            var urlDataWithLongUrl = urlDatas.FirstOrDefault(x => x.LongUrl == longUrl);
            if (urlDataWithLongUrl is not null) {
                return new ShortenResult {
                    Status = Status.UrlAlreadyShortened,
                    UrlData = urlDataWithLongUrl
                };
            }

            var newUrlData = new UrlData {
                Key = key,
                LongUrl = longUrl,
                ShortUrl = $"{this.navigationManager.BaseUri}{key}"
            };

            urlDatas.Add(newUrlData);

            return new ShortenResult { 
                Status = Status.Success,
                UrlData = newUrlData
            };
        }
        public void Delete(string key) {
            var dataToDelete = this.urlDatas.FirstOrDefault(x => x.Key == key);
            if (dataToDelete is not null) { 
                this.urlDatas.Remove(dataToDelete);
            }
        }
    }


    public enum Status { 
        Success, 
        KeyAlreadyExists,
        UrlAlreadyShortened
    }

    public class ShortenResult {
        public Status Status;
        public UrlData UrlData = new UrlData();
    }
}
