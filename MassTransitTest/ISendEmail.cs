namespace MassTransitTest
{
    public interface ISendEmail
    {
        string Email { get; }

        string Recipient { get; }
    }
}
