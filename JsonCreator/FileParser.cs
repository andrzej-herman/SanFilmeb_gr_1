using SanBlazorCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonCreator
{
    internal class FileParser
    {
        private readonly string path;

        public FileParser(string path)
        {
            this.path = path;
        }

        public List<Movie> GetMovies()
        {
            Console.WriteLine();
            Console.WriteLine(" Rozpoczynam parsowanie pliku ...");
            var result = new List<Movie>();
            var lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                if (IsAccepted(line))
                {
                    var parts = line.Split("\t");
                    if (parts.Length == 10)
                    {
                        result.Add(CreateMovie(parts));
                    }
                }
            }

            Console.WriteLine(" Parsowanie OK");
            Console.WriteLine($" Utworzono {result.Count} filmów ...");
            return result;
        }

        private bool IsAccepted(string line)
        {
            return !string.IsNullOrEmpty(line) && !string.IsNullOrWhiteSpace(line); 
        }

        private Movie CreateMovie(string[] parts)
        {
            var movie = new Movie
            {
                Id = Guid.NewGuid().ToString(),
                Title = parts[0],
                OriginalTitle = parts[1],
                Director = parts[2],
                Genre = parts[3],
                Screenplay = parts[4],
                Year = parts[5],
                Trailer = parts[8],
                Description = parts[9],
            };

            var cast = parts[6].Split(",");
            foreach (var c in cast)
                movie.Cast.Add(c.Trim());

            var images = parts[7].Split(",");
            foreach (var i in images)
                movie.Images.Add(i.Trim());

            return movie;

        }
    }
}
