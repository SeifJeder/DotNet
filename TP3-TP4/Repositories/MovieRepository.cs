using Microsoft.EntityFrameworkCore;
using System;
using TP3.Models;
using TP3.Repositories.RepositoryContracts;

namespace TP3.Repositories
{
    public class MovieRepository:IMovieRepository
    {
        private readonly ApplicationDbContext _db;

        public MovieRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Movie> GetAllMovies()
        {
            return _db.Movie.ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _db.Movie.Find(id);
        }

        public void CreateMovie(Movie movie)
        {
            if (movie.ImageFile != null && movie.ImageFile.Length > 0)
            {
                var imagePath = Path.Combine("wwwroot/images", movie.ImageFile.FileName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    movie.ImageFile.CopyTo(stream);
                }

                movie.Photo = $"/images/{movie.ImageFile.FileName}";
            }

            _db.Movie.Add(movie);
            _db.SaveChanges();
        }

        public void EditMovie(Movie movie)
        {
            _db.Entry(movie).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteMovie(int id)
        {
            var movie = _db.Movie.Find(id);

            if (movie != null)
            {
                _db.Movie.Remove(movie);
                _db.SaveChanges();
            }
        }

        public List<Movie> GetMoviesByGenre(int genreId)
        {
            return _db.Movie
                .Where(m => m.GenreId == genreId)
                .ToList();
        }

        public List<Movie> GetAllMoviesOrderedAscending()
        {
            return _db.Movie
                .OrderBy(m => m.Name)
                .ToList();
        }

        public List<Movie> GetMoviesByUserDefinedGenre(string userDefinedGenre)
        {
            return _db.Movie
                .Where(m => m.Genre.GenreName == userDefinedGenre)
                .ToList();
        }
    }
}

