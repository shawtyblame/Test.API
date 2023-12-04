namespace Test.API;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Email { get; set; }= null!;
    public string PhoneNumber { get; set; } = null!;
    public int PassportSeries { get; set; }
    public int PassportNumber { get; set; } 
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
}
