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
    [Authorize(Roles = "Admin")]
    public class GenresController : Controller
    {

        //private DatabaseContext db = new DatabaseContext();
        private IGenreMock bl;
        public GenresController(IGenreMock bl) {
            this.bl = bl;
        }
        /*IGenreMock db;

        public GenresController() {
            this.db = new EFGenre();
        }

        public GenresController(IGenreMock genreMock) {
            this.db = genreMock;
        }*/
        // GET: Genres
        [Route("Genres")]
        [Route("Genres/Index")]
        [AllowAnonymous]
        public ActionResult Index()
        {
            //return View(db.Genres.OrderBy(c => c.Name).ToList());
            return View("Index");
        }

        // GET: Genres/Details/5
        [Route("Genres/Details")]
        public ActionResult Details(int id)
        {
            /*if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }*/
            //Genre genre = db.Genres.Find(id);
            Genre genre = bl.GetGenre(id);
            //Genre genre = db.Genres.SingleOrDefault(c => c.GenreId == id);
            if (genre == null)
            {
                return View("Error");
            }
            return View("Details",genre);
        }
        
        // GET: Genres/Create
        [Route("Genres/Create")]
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Genres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Genres/Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GenreId,Name,Description")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                //db.Genres.Add(genre);
                //db.SaveChanges();
                bl.CreateGenre(genre);
                return RedirectToAction("Index");
            }

            return View(genre);
        }

        // GET: Genres/Edit/5
        [Route("Genres/Edit")]
        public ActionResult Edit(int id)
        {
            /*if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }*/
            //Genre genre = db.Genres.Find(id);
            Genre genre = bl.GetGenre(id);
            if (genre == null)
            {
                return View("Error");
            }
            return View("Edit",genre);
        }

        // POST: Genres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Genres/Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GenreId,Name,Description")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(genre).State = EntityState.Modified;
                //db.SaveChanges();
                bl.Save(genre);
                return RedirectToAction("Index");
            }
            return View("Edit",genre);
        }

        // GET: Genres/Delete/5
        [Route("Genres/Delete")]
        public ActionResult Delete(int id)
        {
            /*if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }*/
            //Genre genre = db.Genres.Find(id);
            Genre genre = bl.GetGenre(id);
            if (genre == null)
            {
                return View("Error");
            }
            return View("Delete",genre);
        }

        // POST: Genres/Delete/5
        [Route("Genres/Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Genre genre = db.Genres.Find(id);
            Genre genre = bl.GetGenre(id);
            //db.Genres.Remove(genre);
            //db.SaveChanges();
            bl.DeleteGenre(genre);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                bl.Dispose();
                
            }
            base.Dispose(disposing);
        }
    }
}
