using ImageUpload.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ImageUpload.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IctionResult UploadImage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UploadImage(ImageModel model, HttpPostedFileBase file)
        {
            if(file != null && file.ContentLength>0) { }
        }
    }
}