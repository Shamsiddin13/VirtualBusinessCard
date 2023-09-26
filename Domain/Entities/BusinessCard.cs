namespace VirtualBusinessCard.Domain.Entities;
using VirtualBusinessCard.Domain.Commans;


public class BusinessCard : Auditable
{
    public long UserId { get; set; }
    public string Title { get; set; }
    public string Company { get; set; }
}
