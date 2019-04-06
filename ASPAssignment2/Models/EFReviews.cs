using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPAssignment2.Models
{
    public class EFReviews : IReviewsMock
    {
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
        }
    }
}