using ASPAssignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPAssignment2.Tests.Fakes
{
    class FakeGenreBL : IGenreMock
    {
        public List<Genre> genres;

        public void CreateGenre(Genre a)
        {
            return;
        }

        public void DetailsGenre(Genre a)
        {
            return;
        }

        public bool DeleteGenre(Genre genre)
        {
            //List<Genre> genres = createGenres();
            if (genres.Contains(genre))
            {
                genres.Remove(genre);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteGenreTest(Genre genre)
        {
            //List<Genre> genres = createGenres();
            if (genres.Contains(genre))
            {
                genres.Remove(genre);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Genre> createGenres()
        {
            Genre comedy = new Genre { GenreId = 1, Name = "Comedy", Description = "deep breath in your tough life" };
            Genre fps = new Genre { GenreId = 2, Name = "FPS", Description = "Men's romance" };
            Genre moba = new Genre { GenreId = 3, Name = "Moba", Description = "Uninstall button onclick" };
            genres = new List<Genre> {
                comedy,
                fps,
                moba
            };
            return genres;
        }
        public Genre GetGenre(int id)
        {
            genres = createGenres();
            try
            {
                Genre toReturn = genres.First(x => x.GenreId == id);
                return toReturn;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IQueryable<Genre> GetGenres()
        {
            return createGenres().AsQueryable();
        }
        public bool UpdateRan = false;
        public int id;
        public Genre a;
        public void UpdateGenre(int id, Genre a)
        {
            UpdateRan = true;
            this.id = id;
            this.a = a;
            return;
        }

        public void Dispose()
        {
        }

        public Genre Save(Genre genre)
        {
            return genre;
        }
    }

}
