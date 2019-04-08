using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPAssignment2.Models
{
    public interface IVideoGamesMock
    {
        IQueryable<VideoGame> GetVideoGames();
        IQueryable<Reviews> GetReviews();
        void UpdateVideoGames(int id, VideoGame videoGame);
        VideoGame SaveVideoGames(VideoGame videoGame);
        bool DeleteVideoGames(VideoGame videoGame);
        void DeleteReviews(Reviews review);
        Reviews SaveReviews(Reviews rev);
        void Dispose();
        VideoGame GetVideoGame(int id);
        Reviews GetReviews(int id);
        void CreateVideoGames(VideoGame videoGame);
    }
}