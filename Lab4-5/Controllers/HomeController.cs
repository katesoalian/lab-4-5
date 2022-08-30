using BLL.Entities;
using BLL.Services;
using Lab4_5.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab4_5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ShowService showService = new ShowService();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Shows = showService.GetAll();

            return View();
        }

        [HttpGet]
        [ActionName("Show")]
        public IActionResult GetTour(int id)
        {
            ShowDTO show = showService.GetShowById(id);

            ViewBag.Show = show;
            ViewBag.ShowId = id;

            if (show.FreePlaces == 0)
            {
                ViewBag.PlacesExist = false;
                return View("~/Views/Home/Show.cshtml");
            }

            ViewBag.PlacesExist = true;
            return View("~/Views/Home/Show.cshtml");
        }

        [HttpGet]
        [ActionName("ReserveShow")]
        public IActionResult GetReserveShow(int id)
        {
            ShowDTO show = showService.GetShowById(id);
            ViewBag.Show = show;
            return View("~/Views/Home/ReserveShow.cshtml");

        }

        [HttpPost]
        [ActionName("ReserveShow")]
        public IActionResult ReserveShow(int id, string firstName, string lastName, string phone, string email)
        {
            if (firstName is not null)
            {
                ViewBag.Message = "Your order has been accepted, please wait for a call from our administrator to confirm";
                ShowDTO show = showService.GetShowById(id);

                show.FreePlaces--;
                showService.UpdateShow(show);
                return View("~/Views/Home/ConfirmMessage.cshtml");
            }

            ViewBag.Price = showService.GetShowById(id).Price;
            return View("~/Views/Home/ReserveShow.cshtml");

        }

        [HttpGet]
        [ActionName("Add")]
        public IActionResult GetAddShow()
        {
            List<string> months = new List<string>();

            months.Add("Січень");
            months.Add("Лютий");
            months.Add("Березень");
            months.Add("Квітень");
            months.Add("Травень");
            months.Add("Червень");
            months.Add("Липень");
            months.Add("Серпень");
            months.Add("Вересень");
            months.Add("Жовтень");
            months.Add("Листопад");
            months.Add("Грудень");

            ViewBag.Months = months;

            return View("~/Views/Home/Add.cshtml");
        }

        [HttpPost]
        [ActionName("Add")]
        public IActionResult AddShow(string name, string author, string genre, int day, int month, int places, int price)
        {
            month++;
            string date = day.ToString() + "." + month.ToString() + "." + DateTime.Now.Year.ToString();
            ShowDTO show = new ShowDTO(name, author, genre, date, price, places);

            showService.AddShow(show);

            ViewBag.Message = "Show successfully added";
            return View("~/Views/Home/ConfirmMessage.cshtml");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}