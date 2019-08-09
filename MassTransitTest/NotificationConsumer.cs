using MassTransit;
using System;
using System.Threading.Tasks;

namespace MassTransitTest
{
    public class NotificationConsumer : IConsumer<IEmailSent>
    {
        public async Task Consume(ConsumeContext<IEmailSent> context)
        {
            await Console.Out.WriteLineAsync(
                $"NotificationConsumer: Message to {context.Message.Email} sent on {context.Message.SentOn:F}");
        }
    }
}
