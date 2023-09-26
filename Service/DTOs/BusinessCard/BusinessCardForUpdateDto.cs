namespace VirtualBusinessCard.Service.DTOs.BusinessCard;

public class BusinessCardForUpdateDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public string Title { get; set; }
    public string Company { get; set; }
}
