using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPAssignment2.Models
{
    interface IReviewsMock
    {
        /*
        IQueryable<Reviews> Reviews { get; }

        Reviews Save(Reviews reviews);
        void Delete(Reviews reviews);

        void Dispose();
        */
        void CreateReviews(Reviews a);
        void DeleteReviews(Reviews a);
        void UpdateReviews(int id, Reviews a);
        Reviews GetReviews(int id);
        IQueryable<Reviews> GetReviews();
    }
}
