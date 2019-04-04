using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPAssignment2.Models
{
    public class EFVideoGames : IVideoGamesMock
    {
        //db connection here
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
        }
    }
}