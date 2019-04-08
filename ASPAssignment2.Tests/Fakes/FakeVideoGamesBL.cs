using ASPAssignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPAssignment2.Tests.Fakes
{
    class FakeVideoGamesBL : IVideoGamesMock
    {
        public List<VideoGame> videoGames;
        public List<Reviews> reviews;

        public void DeleteReviews(Reviews review)
        {
            if (reviews.Contains(review))
            {
                reviews.Remove(review);
            }
        }

        public bool DeleteVideoGames(VideoGame videoGame)
        {
            //List<VideoGame> videoGames = createVideoGames();
            if (videoGames.Contains(videoGame))
            {
                videoGames.Remove(videoGame);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Dispose()
        {
        }

        public void AddReview(int vID, int rID, string sub, int score, string des)
        {
            List<VideoGame> videoGames = createVideoGames();
            List<Reviews> reviews = createReviews();
            VideoGame toReturn;
            try
            {
                toReturn = videoGames.First(x => x.VideoGameId == vID);
            }
            catch (Exception e)
            {
                toReturn = videoGames.FirstOrDefault();
            }

        }
        public VideoGame GetVideoGame(int id)
        {
            videoGames = createVideoGames();
            try
            {
                VideoGame toReturn = videoGames.First(x => x.VideoGameId == id);
                return toReturn;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private List<VideoGame> createVideoGames()
        {
            Genre fps = new Genre {GenreId = 101, Name = "FPS", Description = "First-person shooter." };
            Genre moba = new Genre { GenreId = 100, Name = "Moba", Description = "Angry team simulator." };
            VideoGame game1 = new VideoGame
            {
                VideoGameId = 1,
                Name = "CS : GO",
                Price = 20,
                Developer = "UK",
                Publisher = "Steam",
                Description = "FPS Game",
                Genre = fps
            };
            VideoGame game2 = new VideoGame
            {
                VideoGameId = 2,
                Name = "Card Battle",
                Price = 50,
                Developer = "Developer",
                Publisher = "Publisher",
                Description = "Who knows what goes on",
                Genre = moba
            };
            List<VideoGame> videoGames = new List<VideoGame> { game1, game2 };

            return videoGames;
        }

        public IQueryable<VideoGame> GetVideoGames()
        {
            return createVideoGames().AsQueryable();
        }
        private List<Reviews> createReviews()
        {
            Genre fps = new Genre { GenreId = 1, Name = "FPS", Description = "First-person shooter." };
            VideoGame csgo = new VideoGame
            {
                VideoGameId = 1,
                Name = "CS : GO",
                Price = 20,
                Developer = "UK",
                Publisher = "Steam",
                Description = "FPS Game",
                Genre = fps
            };
            Reviews review1 = new Reviews
            {
                ReviewsId = 1,
                Name = "Craig@email.com",
                Subject = "csgo",
                Review = "I can't play",
                Stars = 4,
                VideoGameId = 1
            };

            Reviews review2 = new Reviews
            {
                ReviewsId = 2,
                Name = "Alex@email.com",
                Subject = "csgo",
                Review = "I am top 500",
                Stars = 5,
                VideoGameId = 1
            };
            List<Reviews> reviews = new List<Reviews> { review1, review2 };
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
            reviews = createReviews();
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
