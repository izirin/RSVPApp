using RSVPApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace RSVPApp.Controllers
{
    public class InvitationController : Controller
    {
        private RSVPContext _context;
        public ViewResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(GuestRespond gRespond)
        {
            if (ModelState.IsValid)
            {
                if (gRespond.Attend.Value)
                    return RedirectToAction("Thanks");
                else
                    return View("Sorry");
            }
            return View(gRespond);
        }
        public ActionResult Thanks()
        {
            return View();
        }
    }
}