namespace VirtualBusinessCard.Domain.Entities;
using VirtualBusinessCard.Domain.Commans;


public class Contact : Auditable
{
    public long BusinessCardId { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string JobTitle { get; set; }

}
