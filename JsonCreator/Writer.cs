using Newtonsoft.Json;
using SanBlazorCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonCreator
{
    internal class Writer
    {
        private readonly string path;
        private readonly List<Movie> movies;

        public Writer(string path, List<Movie> movies)
        {
            this.path = path;
            this.movies = movies;
        }

        public void CreateFile()
        {
            Console.WriteLine();
            Console.WriteLine(" Zapis pliku ...");
            var json = JsonConvert.SerializeObject(this.movies);
            File.WriteAllText(path, json);
            Console.WriteLine($" Plik zapisano w {path}");
        }
    }
}
