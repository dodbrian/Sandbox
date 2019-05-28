using System;

namespace MassTransitTest
{
    public interface IEmailSent
    {
        string Email { get; }

        DateTime SentOn { get; }
    }
}
