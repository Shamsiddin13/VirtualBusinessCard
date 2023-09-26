namespace VirtualBusinessCard.Service.Exceptions;

public class VirtualBusinessCardException : Exception
{
    public int StatusCode { get; set; }

    public VirtualBusinessCardException(int code, string message) : base(message)
    {
        this.StatusCode = code;       
    }

    public VirtualBusinessCardException()
    {
    }
}
