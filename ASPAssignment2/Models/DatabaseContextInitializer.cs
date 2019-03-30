using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASPAssignment2.Models
{
    public class DatabaseContextInitializer : DropCreateDatabaseAlways<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            Genre comedy = new Genre { Name = "Comedy", Description = "deep breath in your tough life" };
            Genre fps = new Genre { Name = "FPS", Description = "Men's romance" };
            Genre moba = new Genre { Name = "Moba", Description = "Uninstall button onclick" };
            context.Genres.Add(comedy);
            context.Genres.Add(fps);
            context.Genres.Add(moba);
            List<Reviews> csgoReviews = new List<Reviews>();
            VideoGame csgo = new VideoGame
            {
                Name = "CSGO",
                Price = 20,
                Developer = "UK",
                Publisher = "steam",
                Description = "FPS Game",
                Genre = fps,
                Reviews = new List<Reviews>()
            };
            context.VideoGames.Add(csgo);
            Reviews review = new Reviews
            {
                Name = "Craig",
                Subject = "csgo",
                Review = "I can't play",
                Stars = 4,
                VideoGame = csgo
            };
            

            base.Seed(context);

        }
    }
}
