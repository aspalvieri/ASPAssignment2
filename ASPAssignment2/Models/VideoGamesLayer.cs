using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASPAssignment2.Models
{
    public class VideoGamesLayer : IVideoGamesMock
    {
        /*//db connection here
        private DatabaseContext db = new DatabaseContext();
        public IQueryable<VideoGame> videoGames { get { return db.VideoGames; } }

        public IQueryable<Reviews> Reviews { get { return db.Reviews; } }

        
        public void Delete(VideoGame videoGame)
        {
            db.VideoGames.Remove(videoGame);
            db.SaveChanges();
        }

        public void Delete(Reviews review)
        {
            db.Reviews.Remove(review);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public VideoGame Save(VideoGame videoGame)
        {
            if (videoGame.VideoGameId == 0)
            {
                db.VideoGames.Add(videoGame);
            }
            else {
                db.Entry(videoGame).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();
            return videoGame;
        }

        public void Save(Reviews rev)
        {
            if (rev.ReviewsId == 0)
            {
                db.Reviews.Add(rev);
            }
            else {
                db.Entry(rev).State = System.Data.Entity.EntityState.Modified;
            }
        }*/
        private DatabaseContext db = new DatabaseContext();

        /*create video games*/
        public void CreateVideoGames(VideoGame videoGame)
        {
            db.VideoGames.Add(videoGame);
            db.SaveChanges();
        }
        /*delete review*/
        public void DeleteReviews(Reviews review)
        {
            db.Reviews.Remove(review);
            db.SaveChanges();
        }
        /*delete video games, if video games does not exist return false, if the video game has reviews delete reviews*/
        public bool DeleteVideoGames(VideoGame videoGame)
        {
            if (videoGame == null)
                return false;
            List<Reviews> reviews = db.Reviews.ToList();
            foreach (Reviews r in reviews)
            {
                if (r.VideoGameId == videoGame.VideoGameId)
                {
                    db.Reviews.Remove(r);
                }
            }
            db.VideoGames.Remove(videoGame);
            db.SaveChanges();
            return true;
        }

        public void Dispose()
        {
            db.Dispose();
        }
        /*get review list*/
        public IQueryable<Reviews> GetReviews()
        {
            return db.Reviews;
        }
        /*get the review*/
        public Reviews GetReviews(int id)
        {
            return db.Reviews.Find(id);
        }
        /*get the videogame*/
        public VideoGame GetVideoGame(int id)
        {
            return db.VideoGames.Find(id);
        }
        /*get the game list*/
        public IQueryable<VideoGame> GetVideoGames()
        {
            return db.VideoGames;
        }
        /*save reviews*/
        public Reviews SaveReviews(Reviews rev)
        {
            if (rev.ReviewsId == 0)
            {
                db.Reviews.Add(rev);
            }
            else
            {
                db.Entry(rev).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();
            return rev;
        }
        /*get the videogame*/
        public VideoGame SaveVideoGames(int id, VideoGame videoGame)
        {
            if (videoGame.VideoGameId == 0)
            {
                db.VideoGames.Add(videoGame);
            }
            else
            {
                db.Entry(videoGame).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();
            return videoGame;
        }
        /*
        public VideoGame SaveVideoGames(VideoGame videoGame)
        {
            if (videoGame.VideoGameId == 0)
            {
                db.VideoGames.Add(videoGame);
            }
            else
            {
                db.Entry(videoGame).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return videoGame;
        }*/
        /*update videogame*/
        public void UpdateVideoGames(int id, VideoGame videoGame)
        {
            db.Entry(videoGame).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}