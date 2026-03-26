using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using PR1Blazor.ApiRequest.Models;

namespace PR1Blazor.ApiRequest;

public class RequestApi
{
 // HttpClient от IHttpClientFactory / DI — один на весь жизненный цикл сервиса
 private readonly HttpClient httpClient;
 
 public RequestApi(HttpClient httpClient)
  {
    this.httpClient = httpClient;
  }

  public async Task<UserData> GetAllUserAsync()
  {
      var url = "/api/UsersLogins/getAllUsers";
      try
      {
          var response = await httpClient.GetAsync(url).ConfigureAwait(false);
          response.EnsureSuccessStatusCode(); // если сервер не вернул 200-299, то выбрасываем исключение
          // берет ответ(JSON) от response и конвертирует в string 
          var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

          if (string.IsNullOrEmpty(responseContent))
          {
              return new UserData();
          }

          // превращает из JSON в объект                   
          var userData = JsonSerializer.Deserialize<UserData>(responseContent, new JsonSerializerOptions
          {
              // не обращай на регистр 
              PropertyNameCaseInsensitive = true,
          });

          return userData ?? new UserData();
      }
      catch(Exception ex)
      {
          Console.WriteLine($"Ошибка в GetAllUserAsync {ex.Message}");
          return new UserData();
      }
  }
  

  public async Task<AuthResponse> AddNewUser(AuthRequest authRequest)
  {
      try
      { var url = "/api/UsersLogins/CreateUserAndLogin";

          var response = await httpClient.PostAsJsonAsync(url, authRequest).ConfigureAwait(false);

          var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

          if (string.IsNullOrEmpty(responseContent))
              return new AuthResponse();

          var result = JsonSerializer.Deserialize<AuthResponse>(responseContent, new JsonSerializerOptions
          {
              PropertyNameCaseInsensitive = true,
          });
          
          return result  ?? new AuthResponse{status = false,  message = "Ошибка соединения"};
      }
      catch (Exception e)
      {
          return new AuthResponse { status = false, message = "Ошибка соединения" };
      }
  }
  
  
  public async Task<UserAddRespons> AddNewUser2(UserShortReq user)
  {
      var url = "/api/UsersLogins/CreateNewUser";
      try
      {
          var response = await httpClient.PostAsJsonAsync(url, user).ConfigureAwait(false);

          var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

          if (string.IsNullOrEmpty(responseContent))
              return new UserAddRespons();

          var result = JsonSerializer.Deserialize<UserAddRespons>(responseContent, new JsonSerializerOptions
          {
              PropertyNameCaseInsensitive = true,
          });
          
          return result  ?? new UserAddRespons{status = false,  message = "Ошибка соединения"};
      }
      catch (Exception ex)
      {
          Console.WriteLine(ex.Message);
          return new UserAddRespons { status = false, message = "Ошибка: " + ex.Message };
      }
  }
  
  public async Task<UserAddRespons> DeleteUserAsync(int userId)
  {
      var url = $"/api/UsersLogins/DeleteUser?IdUSerDelete={userId}";
      try
      {
          var response = await httpClient.DeleteAsync(url).ConfigureAwait(false);

          var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

          if (string.IsNullOrEmpty(responseContent))
              return new UserAddRespons();

          var result = JsonSerializer.Deserialize<UserAddRespons>(responseContent, new JsonSerializerOptions
          {
              PropertyNameCaseInsensitive = true,
          });
          
          return result  ?? new UserAddRespons{status = false,  message = "Ошибка соединения"};
      }
      catch (Exception ex)
      {
          return new UserAddRespons { status = false, message = ex.Message };
      }
  }
  
  public async Task<UserAddRespons> UpdateUserAsync(UpdateUser updateUser)
  {
      var url = "/api/UsersLogins/UpdateUser"; 
      try
      {
          var response = await httpClient.PutAsJsonAsync(url, updateUser).ConfigureAwait(false);

          var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

          if (string.IsNullOrEmpty(responseContent))
              return new UserAddRespons();

          var result = JsonSerializer.Deserialize<UserAddRespons>(responseContent, new JsonSerializerOptions
          {
              PropertyNameCaseInsensitive = true,
          });
          
          return result  ?? new UserAddRespons{status = false,  message = "Ошибка соединения"};
      }
      catch (Exception ex)
      {
          return new UserAddRespons { status = false, message = ex.Message };
      }
  }
 
  // Все что связано с Фильмами
  public async Task<Movie.MovieData> GetMovieAsync()
  {
      var url = "/Info/AllMovies";
      try
      {
          var response = await httpClient.GetAsync(url).ConfigureAwait(false);
          response.EnsureSuccessStatusCode();
          
          var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

          if (string.IsNullOrEmpty(responseContent))
          {
              return new Movie.MovieData();
          }

          var movieData = JsonSerializer.Deserialize<Movie.MovieData>(responseContent, new JsonSerializerOptions
          {
              PropertyNameCaseInsensitive = true,
          });
          
          return movieData ??  new Movie.MovieData();
      }
      catch (Exception e)
      {
          Console.WriteLine($"Ошибка {e.Message}");
          return new Movie.MovieData();
      }
  }

  public async Task<Movie.AddMovieStatus> PostMovieAsync(Movie.AddMovieRequest  movieRequest)
  {
      var url = "/Add/Movie";
      try
      {
          var response = await httpClient.PostAsJsonAsync(url, movieRequest).ConfigureAwait(false);
          response.EnsureSuccessStatusCode();
          
          var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

          if (string.IsNullOrEmpty(responseContent))
          {
              return new Movie.AddMovieStatus();
          }

          var movieData = JsonSerializer.Deserialize<Movie.AddMovieStatus>(responseContent, new JsonSerializerOptions
          {
              PropertyNameCaseInsensitive = true,
          });
          
          return movieData ?? new Movie.AddMovieStatus();
      }
      catch (Exception e)
      {
          Console.WriteLine($"Ошибка {e.Message}");
          return new Movie.AddMovieStatus();
      }
  }

  public async Task<Movie.UpdateMovieStatus> PutMovieAsync(Movie.UpdateMovieRequest movieRequest)
  {
      var url = "/Update/Movie";
      
      try
      {
          var response = await httpClient.PutAsJsonAsync(url, movieRequest).ConfigureAwait(false);
          response.EnsureSuccessStatusCode();

          var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

          if (string.IsNullOrEmpty(responseContent))
          {
              return new Movie.UpdateMovieStatus();
          }

          var movieData = JsonSerializer.Deserialize<Movie.UpdateMovieStatus>(responseContent, new JsonSerializerOptions
          {
              PropertyNameCaseInsensitive = true,
          });

          return movieData ?? new Movie.UpdateMovieStatus();
      }
      catch (Exception e)
      {
          Console.WriteLine($"Ошибка {e.Message}");
          return new Movie.UpdateMovieStatus();
      }

  }

  public async Task<Movie.DeleteMovieStatus> DeleteMovieAsync(int movieId)
  {
      var url = $"/Delete/{movieId}";
      try
      {
          var response = await httpClient.DeleteAsync(url).ConfigureAwait(false);
          response.EnsureSuccessStatusCode();
          
          var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

          if (string.IsNullOrEmpty(responseContent))
          {
              return new Movie.DeleteMovieStatus();
          }

          var dataMovie = JsonSerializer.Deserialize<Movie.DeleteMovieStatus>(responseContent, new JsonSerializerOptions
          {
              PropertyNameCaseInsensitive = true,
          });
          
          return dataMovie ?? new Movie.DeleteMovieStatus();
      }
      catch (Exception e)
      {
          Console.WriteLine($"Ошибка {e.Message}");
          return new Movie.DeleteMovieStatus();
      }
  }
  
  public async Task<Movie.GenreData> GetGenreAsync()
  {
      var url = "/All/Genre";
      try
      {
          var response = await httpClient.GetAsync(url).ConfigureAwait(false);
          response.EnsureSuccessStatusCode();
          
          var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

          if (string.IsNullOrEmpty(responseContent))
          {
              return new Movie.GenreData();
          }

          var movieData = JsonSerializer.Deserialize<Movie.GenreData>(responseContent, new JsonSerializerOptions
          {
              PropertyNameCaseInsensitive = true,
          });
          
          return movieData ??  new Movie.GenreData();
      }
      catch (Exception e)
      {
          Console.WriteLine($"Ошибка {e.Message}");
          return new Movie.GenreData();
      }
  }
  
}