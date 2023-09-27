namespace VirtualBusinessCard.Domain.Entities;
using VirtualBusinessCard.Domain.Commans;


public class BusinessCard : Auditable
{
    public long UserId { get; set; }
    public string Title { get; set; }
    public string Company { get; set; }
    public string Website { get; set; }
    public string Address { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
}
