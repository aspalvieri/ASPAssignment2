using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPAssignment2.Models
{
    public interface IVideoGamesMock
    {
        IQueryable<VideoGame> GetVideoGames();
        void UpdateVideoGames(int id, VideoGame videoGame);
        VideoGame SaveVideoGames(VideoGame videoGame);
        void DeleteVideoGames(VideoGame videoGame);
        void DeleteReviews(Reviews review);
        Reviews SaveReviews(Reviews rev);
        void Dispose();
        VideoGame GetVideoGame(int id);

    }
}