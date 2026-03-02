namespace PR1Blazor.ApiRequest.Models;

public class UserSession
{
    public int? Role { get; set; } 
    public bool IsAdmin => Role == 1; 
}