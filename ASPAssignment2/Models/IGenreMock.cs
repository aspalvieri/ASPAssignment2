using System.Linq;

namespace ASPAssignment2.Models
{
    public interface IGenreMock
    {
        void CreateGenre(Genre a);
        bool DeleteGenre(Genre genre);
        void UpdateGenre(int id, Genre genre);
        Genre GetGenre(int id);
        IQueryable<Genre> GetGenres();
        void Dispose();
        Genre Save(Genre genre);
        bool DeleteGenreTest(Genre genre);
    }
}
