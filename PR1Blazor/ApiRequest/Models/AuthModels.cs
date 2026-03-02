namespace PR1Blazor.ApiRequest.Models;

public class LoginRequest
{
  public string LoginR { get; set; }
  public string PasswordR { get; set; }
  
}

public class AuthRequest
{
  public string Name { get; set; }
  public string Description { get; set; }
  public string Password { get; set; }
  public string Login  { get; set; }
}

public class AuthResponse
{
  public string message { get; set; }
  public bool status { get; set; }
  public int role { get; set; }
}