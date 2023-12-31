﻿using TP3.Models;
using TP3.Repositories.RepositoryContracts;
using TP3.Services.ServicesContracts;

namespace TP3.Services
{
    public class MoviesService:IMoviesService
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public List<Movie> GetAllMovies()
        {
            return _movieRepository.GetAllMovies();
        }

        public Movie GetMovieById(int id)
        {
            return _movieRepository.GetMovieById(id);
        }

        public void CreateMovie(Movie movie)
        {
            _movieRepository.CreateMovie(movie);
        }

        public void Edit(Movie movie)
        {
            _movieRepository.EditMovie(movie);
        }

        public void Delete(int id)
        {
            _movieRepository.DeleteMovie(id);
        }

        public List<Movie> GetMoviesByGenre(int genreId)
        {
            return _movieRepository.GetMoviesByGenre(genreId);
        }

        public List<Movie> GetAllMoviesOrderedAscending()
        {
            return _movieRepository.GetAllMoviesOrderedAscending();
        }
        public List<Movie> GetMoviesByUserDefinedGenre(string userDefinedGenre)
        {
            return _movieRepository.GetMoviesByUserDefinedGenre(userDefinedGenre);
        }
    }
}
