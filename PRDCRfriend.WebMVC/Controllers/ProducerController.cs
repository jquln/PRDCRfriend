using Microsoft.AspNet.Identity;
using PRDCRfriend.Data;
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

        public ActionResult Edit(int id)
        {
            var service = CreateProducerService();
            var detail = service.GetProducerById(id);
            var model =
                new ProducerEdit
                {
                    ProducerId = detail.OwnerId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProducerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ProducerId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateProducerService();

            if (service.UpdateProducer(model))
            {
                TempData["SaveResult"] = "Producer was updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Producer could not be updated ]:");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateProducerService();
            var model = svc.GetProducerById(id);


            return View(model);

        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateProducerService();
            service.DeleteProducer(id);

            TempData["SaveResult"] = "Producer was deleted";

            return RedirectToAction("Index");
        }




        private ProducerService CreateProducerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProducerService(userId);
            return service;
        }


    }
}