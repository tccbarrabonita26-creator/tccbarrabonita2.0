using BarraBonitaTurismo.Data;
using BarraBonitaTurismo.Models;

namespace BarraBonitaTurismo.Services
{
    public interface IDataService
    {
        CityInfo GetCityInfo();
        List<Attraction> GetAttractions();
        List<Attraction> GetAttractionsByCategory(string category);
        Attraction GetAttractionById(int id);
        Attraction AddAttraction(Attraction attraction);
        Attraction UpdateAttraction(Attraction attraction);
        bool DeleteAttraction(int id);

        List<Event> GetEvents();
        List<Event> GetUpcomingEvents(int count);
        Event GetEventById(int id);
        Event AddEvent(Event ev);
        Event UpdateEvent(Event ev);
        bool DeleteEvent(int id);

        List<FAQ> GetFAQs();
        FAQ GetFAQById(int id);
        FAQ AddFAQ(FAQ faq);
        FAQ UpdateFAQ(FAQ faq);
        bool DeleteFAQ(int id);

        List<GuideItem> GetGuideItems();
        List<GuideItem> GetGuideItemsByType(string type);
        GuideItem GetGuideItemById(int id);
        GuideItem AddGuideItem(GuideItem item);
        GuideItem UpdateGuideItem(GuideItem item);
        bool DeleteGuideItem(int id);

        List<ContactMessage> GetContactMessages();

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
            History = @"Barra Bonita foi fundada em 13 de setembro de 1886 por José Theodoro de Souza e outros pioneiros. O nome 'Barra Bonita' origina-se da bela confluência dos rios Tietê e Piracicaba, formando um local de rara beleza natural. A cidade cresceu às margens do Rio Tietê e se tornou um importante polo turístico e econômico da região. <br/><br/> Na década de 1960, com a construção da Usina Hidrelétrica de Barra Bonita, a cidade ganhou ainda mais destaque, formando o famoso Rio de Barra Bonita, que hoje é o principal cartão-postal e atração turística da região.",
            Images = new List<string>
            {
                "/images/cidade/panorama1.jpg",
                "/images/cidade/Rio.jpg",
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

        public Attraction GetAttractionById(int id)
            => _db.Attractions.FirstOrDefault(a => a.Id == id);

        public Attraction AddAttraction(Attraction attraction)
        {
            _db.Attractions.Add(attraction);
            _db.SaveChanges();
            return attraction;
        }

        public Attraction UpdateAttraction(Attraction attraction)
        {
            _db.Attractions.Update(attraction);
            _db.SaveChanges();
            return attraction;
        }

        public bool DeleteAttraction(int id)
        {
            var entity = _db.Attractions.FirstOrDefault(a => a.Id == id);
            if (entity == null) return false;
            _db.Attractions.Remove(entity);
            _db.SaveChanges();
            return true;
        }

        public List<Event> GetEvents()
            => _db.Events.OrderBy(e => e.StartDate).ToList();

        public List<Event> GetUpcomingEvents(int count)
            => _db.Events
                  .OrderBy(e => e.StartDate)
                  .Take(count)
                  .ToList();

        public Event GetEventById(int id)
            => _db.Events.FirstOrDefault(e => e.Id == id);

        public Event AddEvent(Event ev)
        {
            _db.Events.Add(ev);
            _db.SaveChanges();
            return ev;
        }

        public Event UpdateEvent(Event ev)
        {
            _db.Events.Update(ev);
            _db.SaveChanges();
            return ev;
        }

        public bool DeleteEvent(int id)
        {
            var entity = _db.Events.FirstOrDefault(e => e.Id == id);
            if (entity == null) return false;
            _db.Events.Remove(entity);
            _db.SaveChanges();
            return true;
        }

        public List<FAQ> GetFAQs()
            => _db.FAQs.OrderBy(f => f.Order).ToList();

        public FAQ GetFAQById(int id)
            => _db.FAQs.FirstOrDefault(f => f.Id == id);

        public FAQ AddFAQ(FAQ faq)
        {
            _db.FAQs.Add(faq);
            _db.SaveChanges();
            return faq;
        }

        public FAQ UpdateFAQ(FAQ faq)
        {
            _db.FAQs.Update(faq);
            _db.SaveChanges();
            return faq;
        }

        public bool DeleteFAQ(int id)
        {
            var entity = _db.FAQs.FirstOrDefault(f => f.Id == id);
            if (entity == null) return false;
            _db.FAQs.Remove(entity);
            _db.SaveChanges();
            return true;
        }

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

        public GuideItem GetGuideItemById(int id)
            => _db.GuideItems.FirstOrDefault(g => g.Id == id);

        public GuideItem AddGuideItem(GuideItem item)
        {
            _db.GuideItems.Add(item);
            _db.SaveChanges();
            return item;
        }

        public GuideItem UpdateGuideItem(GuideItem item)
        {
            _db.GuideItems.Update(item);
            _db.SaveChanges();
            return item;
        }

        public bool DeleteGuideItem(int id)
        {
            var entity = _db.GuideItems.FirstOrDefault(g => g.Id == id);
            if (entity == null) return false;
            _db.GuideItems.Remove(entity);
            _db.SaveChanges();
            return true;
        }

        public List<ContactMessage> GetContactMessages()
            => _db.ContactMessages.OrderByDescending(c => c.SentAt).ToList();

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
