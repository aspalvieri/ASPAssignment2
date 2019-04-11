using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASPAssignment2.Models
{
    /*initialize database*/
    public class DatabaseContextInitializer : DropCreateDatabaseAlways<DatabaseContext>
    {
        /*create seeds*/
        protected override void Seed(DatabaseContext context)
        {
            Genre comedy = new Genre { Name = "Comedy", Description = "Deep breath in your tough life." };
            Genre fps = new Genre { Name = "FPS", Description = "First-person shooter." };
            Genre moba = new Genre { Name = "Moba", Description = "Angry team simulator." };
            Genre survival = new Genre { Name = "Survival", Description = "Over-used genre, but still fun." };
            context.Genres.Add(comedy);
            context.Genres.Add(fps);
            context.Genres.Add(moba);
            List<Reviews> csgoReviews = new List<Reviews>();
            VideoGame csgo = new VideoGame
            {
                Name = "CS : GO",
                Price = 20,
                Developer = "UK",
                Publisher = "Steam",
                Description = "FPS Game",
                Genre = fps
            };
            context.VideoGames.Add(csgo);
            VideoGame game2 = new VideoGame
            {
                Name = "Card Battle",
                Price = 50,
                Developer = "Developer",
                Publisher = "Publisher",
                Description = "Who knows what goes on",
                Genre = moba
            };
            context.VideoGames.Add(game2);
            VideoGame game3 = new VideoGame
            {
                Name = "Terraria",
                Price = 11,
                Developer = "Re-Logic",
                Publisher = "Steam",
                Description = "Decent survival game",
                Genre = survival
            };
            context.VideoGames.Add(game3);
            Reviews review = new Reviews
            {
                Name = "Craig@email.com",
                Subject = "csgo",
                Review = "I can't play",
                Stars = 4,
                VideoGame = csgo,
                VideoGameId = 1
            };
            context.Reviews.Add(review);

            base.Seed(context);

        }
    }
    /*initialize*/
    public class AccountContextInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            base.Seed(context);
        }
    }
}
