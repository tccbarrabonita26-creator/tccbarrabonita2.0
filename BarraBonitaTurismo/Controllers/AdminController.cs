using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using BarraBonitaTurismo.Models;
using BarraBonitaTurismo.Services;
using BarraBonitaTurismo.Filters;

namespace BarraBonitaTurismo.Controllers
{
    public class AdminController : Controller
    {
        private readonly IDataService _dataService;
        private readonly IConfiguration _config;

        public AdminController(IDataService dataService, IConfiguration config)
        {
            _dataService = dataService;
            _config = config;
        }

        // ───────────────────────────── LOGIN ─────────────────────────────

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("AdminLogado") == "true")
                return RedirectToAction(nameof(Dashboard));

            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var validUser = _config["AdminCredentials:Username"];
            var validPass = _config["AdminCredentials:Password"];

            if (username == validUser && password == validPass)
            {
                HttpContext.Session.SetString("AdminLogado", "true");
                HttpContext.Session.SetString("AdminUser", username);
                return RedirectToAction(nameof(Dashboard));
            }

            ViewBag.Error = "Usuário ou senha inválidos.";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }

        // ───────────────────────────── DASHBOARD ─────────────────────────────

        [AdminAuthFilter]
        public IActionResult Dashboard()
        {
            ViewBag.TotalAttractions = _dataService.GetAttractions().Count;
            ViewBag.TotalEvents = _dataService.GetEvents().Count;
            ViewBag.TotalFAQs = _dataService.GetFAQs().Count;
            ViewBag.TotalGuideItems = _dataService.GetGuideItems().Count;
            return View();
        }

        // ───────────────────────────── ATRAÇÕES ─────────────────────────────

        [AdminAuthFilter]
        public IActionResult Attractions()
        {
            return View(_dataService.GetAttractions());
        }

        [AdminAuthFilter]
        [HttpGet]
        public IActionResult AttractionForm(int? id)
        {
            var attraction = id.HasValue ? _dataService.GetAttractionById(id.Value) : new Attraction();
            if (id.HasValue && attraction == null) return NotFound();
            return View(attraction);
        }

        [AdminAuthFilter]
        [HttpPost]
        public IActionResult AttractionForm(Attraction model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.Id == 0)
                _dataService.AddAttraction(model);
            else
                _dataService.UpdateAttraction(model);

            TempData["Success"] = "Atração salva com sucesso!";
            return RedirectToAction(nameof(Attractions));
        }

        [AdminAuthFilter]
        [HttpPost]
        public IActionResult AttractionDelete(int id)
        {
            _dataService.DeleteAttraction(id);
            TempData["Success"] = "Atração excluída com sucesso!";
            return RedirectToAction(nameof(Attractions));
        }

        // ───────────────────────────── EVENTOS ─────────────────────────────

        [AdminAuthFilter]
        public IActionResult Events()
        {
            return View(_dataService.GetEvents());
        }

        [AdminAuthFilter]
        [HttpGet]
        public IActionResult EventForm(int? id)
        {
            var ev = id.HasValue ? _dataService.GetEventById(id.Value) : new Event { StartDate = DateTime.Today };
            if (id.HasValue && ev == null) return NotFound();
            return View(ev);
        }

        [AdminAuthFilter]
        [HttpPost]
        public IActionResult EventForm(Event model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.Id == 0)
                _dataService.AddEvent(model);
            else
                _dataService.UpdateEvent(model);

            TempData["Success"] = "Evento salvo com sucesso!";
            return RedirectToAction(nameof(Events));
        }

        [AdminAuthFilter]
        [HttpPost]
        public IActionResult EventDelete(int id)
        {
            _dataService.DeleteEvent(id);
            TempData["Success"] = "Evento excluído com sucesso!";
            return RedirectToAction(nameof(Events));
        }

        // ───────────────────────────── FAQ ─────────────────────────────

        [AdminAuthFilter]
        public IActionResult FAQs()
        {
            return View(_dataService.GetFAQs());
        }

        [AdminAuthFilter]
        [HttpGet]
        public IActionResult FAQForm(int? id)
        {
            var faq = id.HasValue ? _dataService.GetFAQById(id.Value) : new FAQ();
            if (id.HasValue && faq == null) return NotFound();
            return View(faq);
        }

        [AdminAuthFilter]
        [HttpPost]
        public IActionResult FAQForm(FAQ model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.Id == 0)
                _dataService.AddFAQ(model);
            else
                _dataService.UpdateFAQ(model);

            TempData["Success"] = "Pergunta frequente salva com sucesso!";
            return RedirectToAction(nameof(FAQs));
        }

        [AdminAuthFilter]
        [HttpPost]
        public IActionResult FAQDelete(int id)
        {
            _dataService.DeleteFAQ(id);
            TempData["Success"] = "Pergunta excluída com sucesso!";
            return RedirectToAction(nameof(FAQs));
        }

        // ───────────────────────────── GUIA ─────────────────────────────

        [AdminAuthFilter]
        public IActionResult GuideItems()
        {
            return View(_dataService.GetGuideItems());
        }

        [AdminAuthFilter]
        [HttpGet]
        public IActionResult GuideItemForm(int? id)
        {
            var item = id.HasValue ? _dataService.GetGuideItemById(id.Value) : new GuideItem { Type = "Hospedagem", Rating = 5 };
            if (id.HasValue && item == null) return NotFound();
            return View(item);
        }

        [AdminAuthFilter]
        [HttpPost]
        public IActionResult GuideItemForm(GuideItem model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.Id == 0)
                _dataService.AddGuideItem(model);
            else
                _dataService.UpdateGuideItem(model);

            TempData["Success"] = "Item do guia salvo com sucesso!";
            return RedirectToAction(nameof(GuideItems));
        }

        [AdminAuthFilter]
        [HttpPost]
        public IActionResult GuideItemDelete(int id)
        {
            _dataService.DeleteGuideItem(id);
            TempData["Success"] = "Item excluído com sucesso!";
            return RedirectToAction(nameof(GuideItems));
        }

        // ───────────────────────────── (Mensagens removidas) ─────────────────────────────
    }
}
