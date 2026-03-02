namespace PR1Blazor.ApiRequest.Models;

public class UserDataShort // user из models
{
    public int id_User { get; set; }
    public string Name { get; set; }
    public string Descrioption { get; set; }
}
public class UserData // OkObjectResult аналог
{
  public UserDataContainer data { get; set; }
  public bool status { get; set; }
}

public class UserDataContainer // data = new {users = users}
{
    public List<UserDataShort> users { get; set; }
}

public class ProfileResponse
{
    public bool status { get; set; }
    public ProfileData data { get; set; }
}

public class ProfileData
{
    public string name { get; set; }
    public string description { get; set; } 
    public string login { get; set; }
    public int role { get; set; }
}

public class UserShort
{
    public string Name { get; set; } 

    public string Descrioption { get; set; } 

    public string Password { get; set; } 

    public string Login { get; set; } 
}

public class UserAddRespons
{
    public bool status { get; set; }
    public string message { get; set; }
}

public class UpdateUser
{
    public int Id { get; set; } 
    public string Name { get; set; } 
    public string Description { get; set; }
    public string Password { get; set; } 
    public string Login  { get; set; } 
}