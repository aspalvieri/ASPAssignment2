using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPAssignment2.Models;

namespace ASPAssignment2.Controllers
{
    public class VideoGamesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: VideoGames
        [Route("")]
        [Route("VideoGames")]
        [Route("VideoGames/Index")]
 
        public ActionResult Index()
        {
            return View();
        }

        // GET: VideoGames/Games
        [Authorize(Roles = "Admin")]
        [Route("VideoGames/VideoGames")]
        [AllowAnonymous]
        public ActionResult VideoGames()
        {
            var videoGames = db.VideoGames.Include(v => v.Genre);
            return View(videoGames.OrderBy(o => o.Name).ToList());
            //return View(videoGames.OrderBy(o => o.Genre).ThenBy(o => o.Name).ToList());
        }

        // GET: VideoGames/Details/5
        [Authorize]
        [Route("VideoGames/Details")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoGame videoGame = db.VideoGames.Find(id);
            if (videoGame == null)
            {
                return HttpNotFound();
            }
            List<Reviews> reviews = db.Reviews.Include(r => r.VideoGame).ToList();
            
            return View(videoGame);
        }

        [Authorize]
        [System.Web.Services.WebMethod]
        [Route("VideoGames/AddReview")]
        public string AddReview(string data)
        {
            
            return User.Identity.Name;
        }

        // GET: VideoGames/Create
        [Authorize(Roles = "Admin")]
        [Route("VideoGames/Create")]
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name");
            return View();
        }

        // POST: VideoGames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [Route("VideoGames/Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VideoGameId,GenreId,Name,Price,Developer,Publisher,Description")] VideoGame videoGame)
        {
            if (ModelState.IsValid)
            {
                db.VideoGames.Add(videoGame);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", videoGame.GenreId);
            return View(videoGame);
        }

        // GET: VideoGames/Edit/5
        [Authorize(Roles = "Admin")]
        [Route("VideoGames/Edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoGame videoGame = db.VideoGames.Find(id);
            if (videoGame == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", videoGame.GenreId);
            return View(videoGame);
        }

        // POST: VideoGames/Edit/5
        [Route("VideoGames/Edit")]
        [Authorize(Roles = "Admin")]
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VideoGameId,GenreId,Name,Price,Developer,Publisher,Description")] VideoGame videoGame)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videoGame).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", videoGame.GenreId);
            return View(videoGame);
        }

        // GET: VideoGames/Delete/5
        [Route("VideoGames/Delete")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoGame videoGame = db.VideoGames.Find(id);
            if (videoGame == null)
            {
                return HttpNotFound();
            }
            return View(videoGame);
        }

        // POST: VideoGames/Delete/5
        [Route("VideoGames/Delete")]
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VideoGame videoGame = db.VideoGames.Find(id);
            db.VideoGames.Remove(videoGame);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
