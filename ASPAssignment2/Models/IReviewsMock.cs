using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPAssignment2.Models
{
    interface IReviewsMock
    {
        IQueryable<Reviews> Reviews { get; }

        Reviews Save(Reviews reviews);
        void Delete(Reviews reviews);

        void Dispose();
    }
}
