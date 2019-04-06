using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPAssignment2.Models
{
    public class GenreLayer : IGenreMock
    {
        /*private DatabaseContext db = new DatabaseContext();
        public IQueryable<Genre> genres { get { return db.Genres; } }

        public void Delete(Genre genre)
        {
            db.Genres.Remove(genre);
            db.SaveChanges();
        }*/


        public void Dispose()
        {
            db.Dispose();
        }
        public Genre Save(Genre genre)
        {
            if (genre.GenreId == 0)
            {
                db.Genres.Add(genre);
            }
            else
            {
                db.Entry(genre).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();
            return genre;
        }
        private DatabaseContext db = new DatabaseContext();
        public void CreateGenre(Genre a)
        {
            db.Genres.Add(a);
            db.SaveChanges();
        }

        public void DeleteGenre(Genre genre)
        {
            db.Genres.Remove(genre);
            db.SaveChanges();
        }

        public Genre GetGenre(int id)
        {
            return db.Genres.Find(id);
        }



        public IQueryable<Genre> GetGenres()
        {
            return db.Genres;
        }
    }
}