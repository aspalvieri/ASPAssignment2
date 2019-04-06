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
        public void DeleteReviews(Reviews review)
        {
            db.Reviews.Remove(review);
            db.SaveChanges();
        }

        public void DeleteVideoGames(VideoGame videoGame)
        {
            db.VideoGames.Remove(videoGame);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public VideoGame GetVideoGame(int id)
        {
            return db.VideoGames.Find(id);
        }

        public IQueryable<VideoGame> GetVideoGames()
        {
            return db.VideoGames;
        }

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

        public VideoGame SaveVideoGames(VideoGame videoGame)
        {
            throw new NotImplementedException();
        }

        public void UpdateVideoGames(int id, VideoGame videoGame)
        {
            db.Entry(videoGame).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}