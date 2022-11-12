using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanBlazorCommon
{
    public class Movie
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string OriginalTitle { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public string Screenplay { get; set; }
        public string Year { get; set; }
        public List<string> Cast { get; set; } = new();
        public List<string> Images { get; set; } = new();
        public string Trailer { get; set; }
        public string Description { get; set; }
    }
}
