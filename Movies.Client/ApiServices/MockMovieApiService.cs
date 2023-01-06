using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Movies.Client.Models;

namespace Movies.Client.ApiServices
{
    public class MockMovieApiService : IMovieApiService
    {
        public async Task<IEnumerable<Movie>> GetMovies()
        {
            var list = new List<Movie>();

            list.Add(new Movie
            {
                Id          = 1,
                Genre       = "Drama",
                Title       = "The Shawshank Redemption",
                Rating      = "9.3",
                ImageUrl    = "images/src",
                ReleaseDate = new DateTime(1994, 5, 5),
                Owner       = "alice"
            });

            return list;
        }

        public Task<Movie> GetMovie(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Movie> CreateMovie(Movie movie)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteMovie(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Movie> UpdateMovie(Movie movie)
        {
            throw new System.NotImplementedException();
        }
    }
}
