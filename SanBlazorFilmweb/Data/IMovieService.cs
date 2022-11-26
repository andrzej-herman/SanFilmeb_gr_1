using SanBlazorCommon;

namespace SanBlazorFilmweb.Data
{
    public interface IMovieService
    {
        IEnumerable<ShortMovie> GetRandomMovies();
        IEnumerable<ShortMovie> SearchMovies(string phrase);
        Movie GetMovieById(string id);
    }
}
