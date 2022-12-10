using Newtonsoft.Json;
using SanBlazorCommon;

namespace SanBlazorFilmweb.Data
{
    public class MovieService : IMovieService
    {
        public MovieService()
        {
            GetAllMovies();
            _random= new Random();
        }


        private IEnumerable<Movie> _allMovies;
        private Random _random;


        private void GetAllMovies()
        {
            var path = "wwwroot\\data\\filmy_3.json";
            var content  = File.ReadAllText(path);
            _allMovies = JsonConvert.DeserializeObject<IEnumerable<Movie>>(content);
        }


        public Movie GetMovieById(string id)
        {
            return _allMovies.FirstOrDefault(x => x.Id == id);  
        }

        public IEnumerable<ShortMovie> GetRandomMovies()
        {
            return _allMovies.OrderBy(x => _random.Next()).Take(6).Select(x => Map(x));
        }

        public IEnumerable<ShortMovie> SearchMovies(string phrase)
        {
            var result = new List<Movie>();
            foreach (var movie in _allMovies)
            {
                foreach (var actor in movie.Cast)
                {
                    if (actor.ToLower().Contains(phrase.ToLower()))
                        result.Add(movie);
                }
            }


            var movies = _allMovies.Where(x => x.Title.ToLower().Contains(phrase.ToLower())
                    || x.Director.ToLower().Contains(phrase.ToLower()));

            result.AddRange(movies);
            return result.Select(x => Map(x));
        }


        private ShortMovie Map (Movie movie)
        {
            var shortMovie =  new ShortMovie
            {
                Id = movie.Id,
                ImageUrl = movie.Images[0],
                Title= movie.Title,
            };

            if (movie.Description.Length >= 50)
                shortMovie.Descr= movie.Description.Substring(0, 50);
            else
                shortMovie.Descr= movie.Description;

            return shortMovie;
        }

    }
}

