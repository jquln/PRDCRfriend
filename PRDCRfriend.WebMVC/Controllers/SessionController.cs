using Microsoft.AspNet.Identity;
using PRDCRfriend.Data;
using PRDCRfriend.Models.ArtistModels;
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
            
            //var artists = new List<Artist>();
            //var artistsSelectListItems = artists.Select(artist => new SelectListItem
            //{
            //    Text = artist.ToString(),
            //    Value = artist.ToString()
            //}).ToList();
            
                
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

            ModelState.AddModelError("", "Your Recording Session was not scheduled...");

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSessionWithArtist(SessionProducerCreate session)
        {
            var service = CreateSessionService();
            if (!ModelState.IsValid)
                return View(session);

           
            if (!service.CreateSessionWithArtist(session))
            {
                TempData["SaveResult"] = "Your Recording Session was scheduled.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Recording Session was not scheduled.");
            return View(session);
        }


        public ActionResult Details(int id)
        {
            var svc = CreateSessionService();
            var model = svc.GetSessionById(id);

            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var service = CreateSessionService();
            var detail = service.GetSessionById(id);
            var model =
                new SessionEdit
                {
                    Id = detail.Id,
                    ProjectTitle = detail.ProjectTitle,
                    Date = detail.Date,
                    Time = detail.Time,
                   // Duration = detail.Duration,
                    //ArtistId = detail.ArtistId
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SessionEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateSessionService();

            if (service.UpdateSession(model))
            {
                TempData["SaveResult"] = "Your Recording Session was updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Recording Session could not be updated ]:");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateSessionService();
            var model = svc.GetSessionById(id);


            return View(model);

        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateSessionService();
            service.DeleteSession(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }














        private SessionService CreateSessionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SessionService(userId);
            return service;
        }

    }
}