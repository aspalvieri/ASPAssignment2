using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASPAssignment2.Models
{
    /*Business layer inherite from IreviewsMock class*/
    public class ReviewsLayer : IReviewsMock
    {
        /*
        private DatabaseContext db = new DatabaseContext();
        public IQueryable<Reviews> Reviews { get { return db.Reviews; } }


        public void Delete(Reviews reviews)
        {
            db.Reviews.Remove(reviews);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public Reviews Save(Reviews reviews)
        {
            if (reviews.ReviewsId == 0)
            {
                db.Reviews.Add(reviews);
            }
            else
            {
                db.Entry(reviews).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();
            return reviews;
        }*/
        private DatabaseContext db = new DatabaseContext();
        /*create reviews*/
        public void CreateReviews(Reviews a)
        {
            db.Reviews.Add(a);
            db.SaveChanges();
        }
        /*delete reviews*/
        public void DeleteReviews(Reviews a)
        {
            db.Reviews.Remove(a);
            db.SaveChanges();
        }
        /*get review with id*/
        public Reviews GetReviews(int id)
        {
            return db.Reviews.Find(id);
        }
        /*get review list*/
        public IQueryable<Reviews> GetReviews()
        {
            return db.Reviews;
        }
        /*update reivews*/
        public void UpdateReviews(int id, Reviews a)
        {
            db.Entry(a).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}