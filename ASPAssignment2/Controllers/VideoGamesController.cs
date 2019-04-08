using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ASPAssignment2.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ASPAssignment2.Controllers
{
    public class VideoGamesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        private IVideoGamesMock bl;
        public bool testCase = false;
        public VideoGamesController(IVideoGamesMock bl)
        {
            this.bl = bl;
        }

        // GET: VideoGames
        [Route("")]
        [Route("VideoGames")]
        [Route("VideoGames/Index")]

        public ActionResult Index()
        {
            //return View(db.VideoGames.Include(v => v.Genre).OrderBy(o => o.Name).ToList());
            return View("Index");
        }

        // GET: VideoGames/Games
        [Authorize]//(Roles = "Admin")]
        [Route("VideoGames/VideoGames")]
        [AllowAnonymous]
        public ActionResult VideoGames()
        {

            //return View(db.VideoGames.Include(v => v.Genre).OrderBy(o => o.Name).ToList());

            return View("Index");
            //return View(videoGames.OrderBy(o => o.Genre).ThenBy(o => o.Name).ToList());
        }

        // GET: VideoGames/Details/5
        [Authorize]
        [AllowAnonymous]
        [Route("VideoGames/Details")]
        public ActionResult Details(int id)
        {
            VideoGame videoGame;
            if (!testCase)
            {
                videoGame = db.VideoGames.Find(id);
            }
            else
            {
                videoGame = bl.GetVideoGame(id);
            }
            if (videoGame == null)
            {
                View("Error");
            }
            List<Reviews> reviewList;
            //reviewList = db.Reviews.ToList();
            reviewList = bl.GetReviews().ToList();
            /*if (!testCase) {
                reviewList = db.Reviews.ToList();
            }
            
            else {
                reviewList = bl.GetReviews();
            }*/
            List<Reviews> reviews = new List<Reviews>();
            foreach (Reviews review in reviewList)
            {
                if (review.VideoGameId == videoGame.VideoGameId)
                {
                    reviews.Add(review);
                }
            }
            videoGame.Reviews = reviews;
            return View("Details", videoGame);
        }

        [Authorize]
        [System.Web.Services.WebMethod]
        [Route("VideoGames/AddReview")]
        public string AddReview(int videogameid, int reviewid, string subject, int stars, string review)
        {
            Reviews rev = new Reviews
            {
                VideoGameId = videogameid,
                ReviewsId = reviewid,
                Name = User.Identity.Name,
                Subject = subject,
                Stars = stars,
                Review = review
            };
            if (rev.CheckModelState())
            {
                if (!testCase)
                {
                    db.Reviews.Add(rev);
                    db.SaveChanges();
                }
                else
                {
                    bl.SaveReviews(rev);
                }
                string data = new JavaScriptSerializer().Serialize(rev);
                return data;
            }
            return "False";
        }

        [Authorize]
        [Route("VideoGames/DeleteReview")]
        public ActionResult DeleteReview(int id, int? reviewid)
        {
            //Ensure user is logged in before deleting a review
            if (!Request.IsAuthenticated)
            {
                return Redirect("VideoGames");
            }
            //Ensure 2 data types were given
            if (reviewid == null)
            {
                return Redirect("VideoGames");
            }
            Reviews review;
            if (!testCase)
            {
                review = db.Reviews.Find(reviewid);
            }
            else
            {
                review = bl.GetReviews(id);
            }
            if (review == null)
            {
                return Redirect("VideoGames");
            }
            if (!testCase)
            {
                db.Reviews.Remove(review);
                db.SaveChanges();
            }
            else
            {
                bl.DeleteReviews(review);
            }
            return Redirect("Details?id=" + id);
        }

        // GET: VideoGames/Create
        [Authorize]//(Roles = "Admin")]
        [Route("VideoGames/Create")]
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name");
            return View("Create");
        }

        // POST: VideoGames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]//(Roles = "Admin")]
        [Route("VideoGames/Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VideoGameId,GenreId,Name,Price,Developer,Publisher,Description")] VideoGame videoGame)
        {
            if (ModelState.IsValid)
            {
                if (!testCase)
                {
                    db.VideoGames.Add(videoGame);
                    db.SaveChanges();
                }
                else
                    bl.CreateVideoGames(videoGame);

            }

            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", videoGame.GenreId);
            return View("Create", videoGame);
        }

        // GET: VideoGames/Edit/5
        [Authorize]//(Roles = "Admin")]
        [Route("VideoGames/Edit")]
        public ActionResult Edit(int id)
        {
            /*if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }*/
            VideoGame videoGame;

            //videoGame = db.VideoGames.Find(id);
            videoGame = bl.GetVideoGame(id);
            if (videoGame == null)
            {
                return View("Error");
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", videoGame.GenreId);
            return View("Edit", videoGame);
        }

        // POST: VideoGames/Edit/5
        [Route("VideoGames/Edit")]
        [Authorize]//(Roles = "Admin")]
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VideoGameId,GenreId,Name,Price,Developer,Publisher,Description")] VideoGame videoGame)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(videoGame).State = EntityState.Modified;
                //db.SaveChanges();
                bl.SaveVideoGames(videoGame);
                return RedirectToAction("VideoGames");
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", videoGame.GenreId);
            return View("Edit", videoGame);
        }

        // GET: VideoGames/Delete/5
        [Route("VideoGames/Delete")]
        [Authorize]//(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            /*if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }*/
            //VideoGame videoGame = db.VideoGames.Find(id);
            VideoGame videoGame = bl.GetVideoGame(id);
            if (videoGame == null)
            {
                return View("Error");
            }
            return View("Delete", videoGame);
        }

        // POST: VideoGames/Delete/5
        [Route("VideoGames/Delete")]
        [Authorize]//(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //VideoGame videoGame = db.VideoGames.Find(id);
            VideoGame videoGame = bl.GetVideoGame(id);
            //db.VideoGames.Remove(videoGame);
            //db.SaveChanges();
            bl.DeleteVideoGames(videoGame);
            return RedirectToAction("VideoGames");
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
