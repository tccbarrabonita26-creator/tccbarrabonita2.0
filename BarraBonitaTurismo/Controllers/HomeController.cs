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

        public IActionResult Guide(string type)
        {
            var items = _dataService.GetGuideItemsByType(type);
            ViewBag.Types = new List<string> { "Hospedagem", "Gastronomia", "Atividades" };
            ViewBag.CurrentType = type;
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