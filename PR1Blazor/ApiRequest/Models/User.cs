namespace PR1Blazor.ApiRequest.Models;

public class UserDataShort // user из models
{
    public int id_User { get; set; }
    public string Name { get; set; }
    public string Login { get; set; }
    public string Descrioption { get; set; }
    public string Password { get; set; }
    public int RoleId { get; set; }
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

public class UserShortReq
{
    public string Name { get; set; } 
    public string Descrioption { get; set; }
    public string Password { get; set; }
    public string Login { get; set; } 
    public int RoleId { get; set; }
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
    public string Descrioption { get; set; }
    public string Password { get; set; } 
    public string Login  { get; set; } 
}

public class CheckId
{
    public int Id_ch { get; set; } 
}

public class AuthUserData
{
    public UserDataShort user { get; set; }
    public bool status { get; set; }
}

public class AuthUser
{
    public string LoginR { get; set; }
    public string PasswordR { get; set; }
}

