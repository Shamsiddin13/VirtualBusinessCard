namespace VirtualBusinessCard.Service.DTOs.BusinessCard;

public class BusinessCardForResultDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public string Title { get; set; }
    public string Company { get; set; }
    public string Website { get; set; }
    public string Address { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
}
