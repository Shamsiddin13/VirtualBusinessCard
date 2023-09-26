namespace VirtualBusinessCard.Domain.Commans;

public abstract class Auditable
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }   
    public DateTime? UpdateAt { get; set; }
}
