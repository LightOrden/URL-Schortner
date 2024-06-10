using Server.Data;
using Server.Models;

namespace Server.Services
{
    public class UrlService:IUrlService
    {
        private readonly AppDbContext _context;
        private readonly string _baseUri;
        public UrlService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _baseUri = configuration["BaseUri"];
        }

        public Url CreateShortUrl(string originalUrl, string createdBy)
        {
            var shortUrl = new Url
            {
                OriginalUrl = originalUrl,
                ShortenedUrl = _baseUri +"/"+ Guid.NewGuid().ToString().Substring(0, 8),
                CreatedDate = DateTime.Now,
                CreatedBy = createdBy
            };
            _context.Urls.Add(shortUrl);
            _context.SaveChanges();
            return shortUrl;
        }

        public Url GetUrlById(int id)
        {
            return _context.Urls.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Url> GetAllUrls()
        {
            return _context.Urls.ToList();
        }

        public void DeleteUrl(int id)
        {
            var url = _context.Urls.FirstOrDefault(u => u.Id == id);
            if (url != null)
            {
                _context.Urls.Remove(url);
                _context.SaveChanges();
            }
        }
    }
}
