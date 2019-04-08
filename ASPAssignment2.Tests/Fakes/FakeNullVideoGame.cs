using ASPAssignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPAssignment2.Tests.Fakes
{
    class FakeNullVideoGame : IVideoGamesMock
    {
        public void DeleteReviews(Reviews review)
        {
            return;
        }

        public void DeleteVideoGames(VideoGame videoGame)
        {
            return;
        }

        public void Dispose()
        {
        }

        public VideoGame GetVideoGame(int id)
        {
            List<VideoGame> videoGames = createVideoGames();
            try
            {
                VideoGame toReturn = videoGames.First(x => x.VideoGameId == id);
                return toReturn;
            }
            catch (Exception e)
            {
                return videoGames.FirstOrDefault();
            }
        }

        private List<VideoGame> createVideoGames()
        {

            List<VideoGame> videoGames = new List<VideoGame> { };

            return videoGames;
        }

        public IQueryable<VideoGame> GetVideoGames()
        {
            return createVideoGames().AsQueryable();
        }
        private List<Reviews> createReviews()
        {
            List<Reviews> reviews = new List<Reviews> { };
            return reviews;
        }

        public IQueryable<Reviews> GetReviews()
        {
            return createReviews().AsQueryable();
        }

        public Reviews SaveReviews(Reviews rev)
        {
            return rev;
        }

        public VideoGame SaveVideoGames(VideoGame videoGame)
        {
            return videoGame;
        }

        public bool UpdateRan = false;
        public int id;
        public VideoGame a;
        public void UpdateVideoGames(int id, VideoGame videoGame)
        {
            UpdateRan = true;
            this.id = id;
            this.a = videoGame;
            return;
        }

        public Reviews GetReviews(int id)
        {
            List<Reviews> reviews = createReviews();
            try
            {
                Reviews toReturn = reviews.First(x => x.ReviewsId == id);
                return toReturn;
            }
            catch (Exception e)
            {
                return reviews.FirstOrDefault();
            }
        }

        public void CreateVideoGames(VideoGame videoGame)
        {
            return;
        }
    }

}
