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
          var  response = await httpClient.GetAsync(url).ConfigureAwait(false);
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
      catch { return new UserData(); }
  }
  

  public async Task<AuthResponse> Authorized(LoginRequest loginRequest)
  {
      try
      { var url = "/api/UsersLogins/AuthorizedUsers";

          var response = await httpClient.PostAsJsonAsync(url, loginRequest).ConfigureAwait(false);

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
  
  public async Task<ProfileResponse> GetMyProfileAsync()
  {
      var url = "/api/UsersLogins/CheckMyProfile"; 
      try
      {
          var  response = await httpClient.GetAsync(url).ConfigureAwait(false);
          response.EnsureSuccessStatusCode(); 
          var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
           
          if(string.IsNullOrEmpty(responseContent))
              return new ProfileResponse();                
          var userData = JsonSerializer.Deserialize<ProfileResponse>(responseContent, new JsonSerializerOptions
          {
              PropertyNameCaseInsensitive = true,
          });
           
          return userData ?? new ProfileResponse { status = false};
      }
      catch 
      { 
          return new ProfileResponse { status = false }; 
      }
  }
  
  public async Task<UserAddRespons> AddNewUser(UserShort user)
  {
      var url = "/api/UsersLogins/CreateUserAndLogin";
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
          var response = await httpClient.PostAsJsonAsync(url, userId).ConfigureAwait(false);

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

  
  
}