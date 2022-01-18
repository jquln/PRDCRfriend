﻿using Microsoft.AspNet.Identity;
using PRDCRfriend.Data;
using PRDCRfriend.Models.ArtistModels;
using PRDCRfriend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRDCRfriend.WebMVC.Controllers
{
    [Authorize]
    public class ArtistController : Controller
    {
        // GET: Artist
        public ActionResult Index()
        {
            var artistId = Guid.Parse(User.Identity.GetUserId());
            var service = new ArtistService(artistId);
            var model = service.GetArtists();

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
        public ActionResult Create(ArtistCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateArtistService();

            if (service.CreateArtist(model))
            {
                TempData["SaveResult"] = "Artist was created!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Artist could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateArtistService();
            var model = svc.GetArtistById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateArtistService();
            var detail = service.GetArtistById(id);
            var model =
                new ArtistEdit
                {
                    ArtistId = detail.ArtistId,
                    ProjectTitle = detail.ProjectTitle,
                    Email = detail.Email,
                    PhoneNumber = detail.PhoneNumber
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ArtistEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ArtistId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateArtistService();

            if (service.UpdateArtist(model))
            {
                TempData["SaveResult"] = "Artist was updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Artist could not be updated ]:");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateArtistService();
            var model = svc.GetArtistById(id);


            return View(model);

        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateArtistService();
            service.DeleteArtist(id);

            TempData["SaveResult"] = "Artist was deleted";

            return RedirectToAction("Index");
        }




        private ArtistService CreateArtistService()
        {
            var artistId = Guid.Parse(User.Identity.GetUserId());
            var artistService = new ArtistService(artistId);
            return artistService;
        }


    }
}