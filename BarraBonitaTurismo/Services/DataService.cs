using BarraBonitaTurismo.Data;
using BarraBonitaTurismo.Models;

namespace BarraBonitaTurismo.Services
{
    public interface IDataService
    {
        CityInfo GetCityInfo();
        List<Attraction> GetAttractions();
        List<Attraction> GetAttractionsByCategory(string category);
        List<Event> GetEvents();
        List<Event> GetUpcomingEvents(int count);
        List<FAQ> GetFAQs();
        List<GuideItem> GetGuideItems();
        List<GuideItem> GetGuideItemsByType(string type);
        bool SendContactMessage(ContactMessage message);
    }

    public class DataService : IDataService
    {
        private readonly AppDbContext _db;

        public DataService(AppDbContext db)
        {
            _db = db;
        }

        // Informações estáticas da cidade (sem necessidade de tabela própria)
        public CityInfo GetCityInfo() => new CityInfo
        {
            Name = "Barra Bonita",
            Foundation = "13 de setembro de 1886",
            Population = "35.000 habitantes",
            Area = "146 km²",
            Slogan = "Capital Náutica do Interior Paulista",
            History = @"Barra Bonita foi fundada em 13 de setembro de 1886 por José Theodoro de Souza e outros pioneiros. O nome 'Barra Bonita' origina-se da bela confluência dos rios Tietê e Piracicaba, formando um local de rara beleza natural. A cidade cresceu às margens do Rio Tietê e se tornou um importante polo turístico e econômico da região. <br/><br/> Na década de 1960, com a construção da Usina Hidrelétrica de Barra Bonita, a cidade ganhou ainda mais destaque, formando o famoso Lago de Barra Bonita, que hoje é o principal cartão-postal e atração turística da região.",
            Images = new List<string>
            {
                "/images/cidade/panorama1.jpg",
                "/images/cidade/lago.jpg",
                "/images/cidade/centro.jpg"
            }
        };

        public List<Attraction> GetAttractions()
            => _db.Attractions.OrderBy(a => a.Id).ToList();

        public List<Attraction> GetAttractionsByCategory(string category)
        {
            if (string.IsNullOrEmpty(category))
                return GetAttractions();
            return _db.Attractions
                      .Where(a => a.Category == category)
                      .OrderBy(a => a.Id)
                      .ToList();
        }

        public List<Event> GetEvents()
            => _db.Events.OrderBy(e => e.StartDate).ToList();

        public List<Event> GetUpcomingEvents(int count)
            => _db.Events
                  .Where(e => e.StartDate >= DateTime.Now)
                  .OrderBy(e => e.StartDate)
                  .Take(count)
                  .ToList();

        public List<FAQ> GetFAQs()
            => _db.FAQs.OrderBy(f => f.Order).ToList();

        public List<GuideItem> GetGuideItems()
            => _db.GuideItems.OrderBy(g => g.Id).ToList();

        public List<GuideItem> GetGuideItemsByType(string type)
        {
            if (string.IsNullOrEmpty(type))
                return GetGuideItems();
            return _db.GuideItems
                      .Where(g => g.Type == type)
                      .OrderBy(g => g.Id)
                      .ToList();
        }

        public bool SendContactMessage(ContactMessage message)
        {
            if (message == null ||
                string.IsNullOrWhiteSpace(message.Name) ||
                string.IsNullOrWhiteSpace(message.Email) ||
                string.IsNullOrWhiteSpace(message.Message))
                return false;

            message.SentAt = DateTime.Now;
            message.IsRead = false;

            _db.ContactMessages.Add(message);
            _db.SaveChanges();
            return true;
        }
    }
}
