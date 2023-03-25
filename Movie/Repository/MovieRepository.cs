using Microsoft.EntityFrameworkCore;
using Movie.Models;

namespace Movie.Repository
{
    public class MovieRepository : IPostRepository
    {
        public MovieGenreContext _genreContext;
       public MovieRepository(MovieGenreContext genreContext)
        { _genreContext = genreContext; }

        public async Task<List<Models.Movie>> GetMovies(string genre)
        {
            if (_genreContext != null)
            {
                var movie = await _genreContext.Movies.Where(x => x.Genre == genre).ToListAsync();
                return movie;
            }
            throw new NotImplementedException();

        }

        public async Task<string> GetGenre(string s)
        {
            if (_genreContext != null)
            {
                var movie = await _genreContext.Movies.Where(x => x.Genre == s).Select(x=>x.Genre).FirstOrDefaultAsync();
                return movie;
            }
            throw new NotImplementedException();
        }



    }
}