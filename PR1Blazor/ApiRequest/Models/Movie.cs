namespace PR1Blazor.ApiRequest.Models;

public class Movie
{
    // Все что связанное с Фильмом

    public class MovieShortData
    {
        public int Id_Movie { get; set; }
        public string Name_Movie { get; set; }
        public string Description_Movie { get; set; }
        public string Genre_Movie { get; set; }
        public int GenreMovieId { get; set; }
        public DateOnly Release_Date { get; set; }
        public double Rating  { get; set; }
        public string? Url { get; set; }
    }

    public class MovieData // OkObjectResult аналог
    {
        public MovieDataContainer data { get; set; }
        public bool status { get; set; }
    }

    public class MovieDataContainer // data = new {users = users}
    {
        public List<MovieShortData> movies { get; set; }
    }
    
    // добавление фильма
    public class AddMovieRequest
    {
        public string NameMovie { get; set; }
        public string DescriptionMovie { get; set; }
        public int GenreMovieId { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public double Rating  { get; set; }
        public string? Url { get; set; }
    }

    public class AddMovieStatus
    {
        public string message { get; set; }
        public bool status { get; set; }
    }
    
    // обновление фильма
    public class UpdateMovieRequest
    {
        public int IdMovie { get; set; }
        public string NameMovie { get; set; }
        public string DescriptionMovie { get; set; }
        public int GenreMovieId { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public double Rating  { get; set; }
        public string? Url { get; set; }
    }
    
    public class UpdateMovieStatus
    {
        public string message { get; set; }
        public bool status { get; set; }
    }
    
    // удаление фильма
    public class DeleteMovieStatus
    {
        public string message { get; set; }
        public bool status { get; set; }
    }
    
    // получение всех жанров 
    public class GenreShortData
    {
        public int Id_GenreMovie { get; set; }
        public string Name_GenreMovie { get; set; }
    }
    
    public class GenreData // OkObjectResult аналог
    {
        public GenreDataContainer data { get; set; }
        public bool status { get; set; }
    }

    public class GenreDataContainer // data = new {users = users}
    {
        public List<GenreShortData> genreMovie { get; set; }
    }
}