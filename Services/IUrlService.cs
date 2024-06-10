using Server.Models;

namespace Server.Services
{
    public interface IUrlService
    {
        Url CreateShortUrl(string originalUrl, string createdBy);
        Url GetUrlById(int id);
        IEnumerable<Url> GetAllUrls();
        void DeleteUrl(int id);
    }

}
