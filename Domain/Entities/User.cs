namespace VirtualBusinessCard.Domain.Entities;
using VirtualBusinessCard.Domain.Commans;


public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
}
