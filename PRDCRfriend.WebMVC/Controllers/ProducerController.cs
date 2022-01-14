using Microsoft.AspNet.Identity;
using PRDCRfriend.Models;
using PRDCRfriend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRDCRfriend.WebMVC.Controllers
{
    [Authorize]
    public class ProducerController : Controller
    {
        // GET: Producer
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProducerService(userId);
            var model = service.GetProducers();

            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProducerCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateProducerService();

            if (service.CreateProducer(model))
            {
                TempData["SaveResult"] = "Producer was created!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Producer could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateProducerService();
            var model = svc.GetProducerById(id);

            return View(model);
        }



        private ProducerService CreateProducerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProducerService(userId);
            return service;
        }


    }
}