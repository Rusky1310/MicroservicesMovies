using Movie.Models;
namespace Movie.Repository
{
    public interface IPostRepository
    {
        Task<List<Models.Movie>> GetMovies(string s);
        Task<string> GetGenre(string s);
    }
}
