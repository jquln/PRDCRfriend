using Microsoft.AspNet.Identity;
using PRDCRfriend.Models.PlannerModels;
using PRDCRfriend.Models.ProjectPlannerModels;
using PRDCRfriend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRDCRfriend.WebMVC.Controllers
{
    [Authorize]
    public class ProjectPlannerController : Controller
    {
        // GET: ProjectPlanner
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProjectPlannerService(userId);
            var model = service.GetPlanners();

            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlannerCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePlannerService();

            if (service.CreatePlanner(model))
            {
                TempData["SaveResult"] = "Your Planner was created!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your Planner was not created");

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("NewPlanner")]
        public ActionResult CreatePlannerWithProducer(PlannerProducerCreate planner)
        {
            if (!ModelState.IsValid)
                return View(planner);

            var service = CreatePlannerService();
            if (!service.CreateProjectPlannerWithProducer(planner))
                return RedirectToAction("Index");

            return View(planner);
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePlannerService();
            var model = svc.GetPlannerById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePlannerService();
            var detail = service.GetPlannerById(id);
            var model =
                new ProjectPlannerEdit
                {
                  
                    ProjectTitle = detail.ProjectTitle,
                    Date = detail.Date,
                    Artist = detail.Artist,
                    Content = detail.Content,
                    ProducerId = detail.ProducerId,
                    
                    //ArtistId = detail.ArtistId
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProjectPlannerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PlannerId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePlannerService();

            if (service.UpdateProjectPlanner(model))
            {
                TempData["SaveResult"] = "Your Planner was updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Planner could not be updated...");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePlannerService();
            var model = svc.GetPlannerById(id);


            return View(model);

        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePlannerService();
            service.DeleteProjectPlanner(id);

            TempData["SaveResult"] = "Your project planner was deleted";

            return RedirectToAction("Index");
        }









        private ProjectPlannerService CreatePlannerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProjectPlannerService(userId);
            return service;
        }


    }
}