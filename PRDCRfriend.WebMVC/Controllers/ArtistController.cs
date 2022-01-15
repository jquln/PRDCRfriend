using Microsoft.AspNet.Identity;
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

        private ArtistService CreateArtistService()
        {
            var artistId = Guid.Parse(User.Identity.GetUserId());
            var artistService = new ArtistService(artistId);
            return artistService;
        }


    }
}