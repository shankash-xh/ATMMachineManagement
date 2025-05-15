namespace DAL.Entity;

public class Users
{
    public int Id { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public bool IsManager { get; set; }
    public Accounts? Account { get; set; }
}
