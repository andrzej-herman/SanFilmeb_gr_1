using JsonCreator;

var source = "D:\\filmy_3.txt";
var dest = "D:\\filmy_3.json";
var parser = new FileParser(source);
var movies = parser.GetMovies();
var writer = new Writer(dest, movies);
writer.CreateFile();
    