using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ASPAssignment2.Models;

namespace ASPAssignment2.Controllers.api
{
    public class VideoGamesController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/VideoGames
        public IQueryable<VideoGame> GetVideoGames()
        {
            return db.VideoGames;
        }

        // GET: api/VideoGames/5
        [ResponseType(typeof(VideoGame))]
        public IHttpActionResult GetVideoGame(int id)
        {
            VideoGame videoGame = db.VideoGames.Find(id);
            if (videoGame == null)
            {
                return NotFound();
            }

            return Ok(videoGame);
        }

        // PUT: api/VideoGames/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVideoGame(int id, VideoGame videoGame)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != videoGame.VideoGameId)
            {
                return BadRequest();
            }

            db.Entry(videoGame).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoGameExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/VideoGames
        [ResponseType(typeof(VideoGame))]
        public IHttpActionResult PostVideoGame(VideoGame videoGame)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VideoGames.Add(videoGame);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = videoGame.VideoGameId }, videoGame);
        }

        // DELETE: api/VideoGames/5
        [ResponseType(typeof(VideoGame))]
        public IHttpActionResult DeleteVideoGame(int id)
        {
            VideoGame videoGame = db.VideoGames.Find(id);
            if (videoGame == null)
            {
                return NotFound();
            }

            db.VideoGames.Remove(videoGame);
            db.SaveChanges();

            return Ok(videoGame);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VideoGameExists(int id)
        {
            return db.VideoGames.Count(e => e.VideoGameId == id) > 0;
        }
    }
}