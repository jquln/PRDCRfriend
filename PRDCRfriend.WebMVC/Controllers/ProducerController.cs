using PRDCRfriend.Models;
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
            var model = new ProducerListItem[0];
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }

    }
}