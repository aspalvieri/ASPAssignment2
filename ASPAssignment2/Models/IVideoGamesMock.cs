using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPAssignment2.Models
{
    public interface IVideoGamesMock
    {
        IQueryable<VideoGame> videoGames { get; }
        IQueryable<Reviews> Reviews { get; }

        VideoGame Save(VideoGame videoGame);
        void Delete(VideoGame videoGame);
        void Delete(Reviews review);
        void Save(Reviews rev);
        void Dispose();
    }
}