using Microsoft.AspNet.Identity;
using PRDCRfriend.Models.SessionModels;
using PRDCRfriend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRDCRfriend.WebMVC.Controllers
{
    [Authorize]
    public class SessionController : Controller
    {
        // GET: Session
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SessionService(userId);
            var model = service.GetSessions();

            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        //Add code here VVVV
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SessionCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateSessionService();

            if (service.CreateSession(model))
            {
                TempData["SaveResult"] = "Your Recording Session was scheduled!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your Recording Session was not scheduled ]:");

            return View(model);
        }
















        private SessionService CreateSessionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SessionService(userId);
            return service;
        }

    }
}