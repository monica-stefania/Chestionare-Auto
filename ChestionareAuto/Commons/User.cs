public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public User(int id, string name, string username, string email, string password)
    {
        Id = id;
        Name = name;
        Username = username;
        Email = email;
        Password = password;
    }

}