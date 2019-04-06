using System.Linq;

namespace ASPAssignment2.Models
{
    public interface IGenreMock
    {
        void CreateGenre(Genre a);
        void DeleteGenre(Genre genre);
        Genre GetGenre(int id);
        IQueryable<Genre> GetGenres();
    }
}
