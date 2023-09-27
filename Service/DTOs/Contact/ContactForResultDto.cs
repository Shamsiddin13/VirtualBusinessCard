namespace VirtualBusinessCard.Service.DTOs.Contact;

public class ContactForResultDto
{
    public long Id { get; set; }
    public long BusinessCardId { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string JobTitle { get; set; }
}
