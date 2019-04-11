using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASPAssignment2.Models
{
    /*class inherite form IgenreMock interface*/
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
        /*save reviews*/
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
        /*create genre*/
        public void CreateGenre(Genre a)
        {
            db.Genres.Add(a);
            db.SaveChanges();
        }
        /*delete genre, if genre used in video games, delete videogames, if the videogames that need to be deleted has reviews, delete reviews first*/
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
        /*delete genre*/
        public bool DeleteGenreTest(Genre genre)
        {
            if (genre == null)
                return false;
            db.Genres.Remove(genre);
            db.SaveChanges();
            return true;
        }
        /*delete genre with id*/
        public Genre GetGenre(int id)
        {
            return db.Genres.Find(id);
        }


        /*get genre list*/
        public IQueryable<Genre> GetGenres()
        {
            return db.Genres;
        }
        /*update genre*/
        public void UpdateGenre(int id, Genre genre)
        {
            db.Entry(genre).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}