using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public bool DeleteGenre(Genre genre)
        {
            if (genre == null)
                return false;
            List<Reviews> reviews = db.Reviews.ToList();
            List<VideoGame> videoGames = db.VideoGames.ToList();
            foreach (VideoGame v in videoGames)
            {
                if (v.GenreId == genre.GenreId)
                {
                    foreach (Reviews r in reviews)
                    {
                        if (r.VideoGameId == v.VideoGameId)
                        {
                            db.Reviews.Remove(r);
                        }
                    }
                }
            }
            db.Genres.Remove(genre);
            db.SaveChanges();
            return true;
        }

        public bool DeleteGenreTest(Genre genre)
        {
            if (genre == null)
                return false;
            db.Genres.Remove(genre);
            db.SaveChanges();
            return true;
        }

        public Genre GetGenre(int id)
        {
            return db.Genres.Find(id);
        }



        public IQueryable<Genre> GetGenres()
        {
            return db.Genres;
        }

        public void UpdateGenre(int id, Genre genre)
        {
            db.Entry(genre).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}