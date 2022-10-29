using JsonCreator;

var source = "D:\\baza_filmow.txt";
var dest = "D:\\filmy.json";
var parser = new FileParser(source);
var movies = parser.GetMovies();
var writer = new Writer(dest, movies);
writer.CreateFile();
    