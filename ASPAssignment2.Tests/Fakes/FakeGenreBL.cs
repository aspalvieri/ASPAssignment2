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
        public void CreateGenre(Genre a)
        {
            return;
        }

        public void DetailsGenre(Genre a)
        {
            return;
        }

        public void DeleteGenre(Genre genre)
        {
            return;
        }

        private List<Genre> createGenres() {
            Genre comedy = new Genre { GenreId = 3, Name = "Comedy", Description = "deep breath in your tough life" };
            Genre fps = new Genre { Name = "FPS", Description = "Men's romance" };
            Genre moba = new Genre { Name = "Moba", Description = "Uninstall button onclick" };
            List<Genre> genres = new List<Genre> {
                comedy,
                fps,
                moba
            };
            return genres;
        }
        public Genre GetGenre(int id)
        {
            List<Genre> albums = createGenres();
            Genre toReturn = albums.First(x => x.GenreId == id);
            return toReturn;
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
