using Microsoft.AspNetCore.Mvc;
using BarraBonitaTurismo.Models;
using BarraBonitaTurismo.Services;

namespace BarraBonitaTurismo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataService _dataService;

        public HomeController(IDataService dataService)
        {
            _dataService = dataService;
        }

        public IActionResult Index()
        {
            var cityInfo = _dataService.GetCityInfo();
            var upcomingEvents = _dataService.GetUpcomingEvents(5);
            var allAttractions = _dataService.GetAttractions();
            var faqs = _dataService.GetFAQs();
            
            var guideByType = new Dictionary<string, List<GuideItem>>
            {
                ["Hospedagem"] = _dataService.GetGuideItemsByType("Hospedagem").Take(2).ToList(),
                ["Gastronomia"] = _dataService.GetGuideItemsByType("Gastronomia").Take(2).ToList(),
                ["Atividades"] = _dataService.GetGuideItemsByType("Atividades").Take(2).ToList()
            };
            
            ViewBag.CityInfo = cityInfo;
            ViewBag.UpcomingEvents = upcomingEvents;
            ViewBag.AllAttractions = allAttractions;
            ViewBag.FAQs = faqs;
            ViewBag.GuideItemsByType = guideByType;
            
            return View();
        }

        [HttpGet]
        [ResponseCache(Duration = 300, VaryByQueryKeys = new[] { "id" })]
        public IActionResult AttractionDetail(int id)
        {
            var all = _dataService.GetAttractions();
            var attraction = all.FirstOrDefault(a => a.Id == id);
            if (attraction == null)
                return NotFound();

            // Atrações relacionadas: mesma categoria, exceto a atual (máx 3)
            var related = all
                .Where(a => a.Id != id && a.Category == attraction.Category)
                .Take(3)
                .ToList();

            // Se não houver suficientes na mesma categoria, completa com outras
            if (related.Count < 3)
            {
                var others = all
                    .Where(a => a.Id != id && a.Category != attraction.Category)
                    .Take(3 - related.Count)
                    .ToList();
                related.AddRange(others);
            }

            ViewBag.Related = related;
            return View(attraction);
        }

        [HttpGet]
        public IActionResult GetAttractionDetail(int id)
        {
            var attraction = _dataService.GetAttractions().FirstOrDefault(a => a.Id == id);
            if (attraction == null)
                return NotFound();
            
            return Json(new
            {
                id = attraction.Id,
                name = attraction.Name,
                description = attraction.Description,
                category = attraction.Category,
                imageUrl = attraction.ImageUrl,
                address = attraction.Address,
                schedule = attraction.Schedule,
                funFact = attraction.FunFact
            });
        }

        [ResponseCache(Duration = 300, VaryByQueryKeys = new[] { "type", "page" })]
        public IActionResult Guide(string type, int page = 1)
        {
            const int pageSize = 6;

            var allItems = _dataService.GetGuideItemsByType(type);
            var totalItems = allItems.Count;
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            if (page < 1) page = 1;
            if (totalPages > 0 && page > totalPages) page = totalPages;

            var items = allItems
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.Types = new List<string> { "Hospedagem", "Gastronomia", "Atividades" };
            ViewBag.CurrentType = type;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            return View(items);
        }

        [HttpPost]
        public IActionResult Contact(ContactMessage message)
        {
            if (ModelState.IsValid)
            {
                if (_dataService.SendContactMessage(message))
                {
                    TempData["Success"] = "Mensagem enviada com sucesso! Entraremos em contato em breve.";
                    return RedirectToAction(nameof(Index) + "#contato");
                }
                ModelState.AddModelError("", "Erro ao enviar mensagem. Tente novamente.");
            }
            return View(message);
        }
    }
}