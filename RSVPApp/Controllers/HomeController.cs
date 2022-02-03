using RSVPApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace RSVPApp.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}