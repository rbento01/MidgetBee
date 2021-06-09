using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MidgetBee.Controllers {
    public class ReviewsController : Controller {
        // GET: Reviews
        public ActionResult Index() {
            return View();
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: Reviews/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Reviews/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            } catch {
                return View();
            }
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: Reviews/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            } catch {
                return View();
            }
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: Reviews/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            } catch {
                return View();
            }
        }
    }
}
