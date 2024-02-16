using KeyedService.Models;
using KeyedService.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KeyedService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IStorageService _storageService;
        public HomeController(ILogger<HomeController> logger, IStorageService storageService)
        {
            _storageService = storageService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _storageService.UploadData("Fake Data");
            return View();
        }

        public IActionResult Privacy()
        {
            _storageService.UploadData("Fake Data");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
