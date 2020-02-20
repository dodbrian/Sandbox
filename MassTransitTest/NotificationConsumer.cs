using System;
using System.Threading.Tasks;
using MassTransit;
using Sandbox.Common;

namespace MassTransitTest
{
    public class NotificationConsumer : IConsumer<IEmailSent>
    {
        public async Task Consume(ConsumeContext<IEmailSent> context)
        {
            await ColoredConsole.WriteLineAsync(
                $"NotificationConsumer: Message to {context.Message.Email} sent on {context.Message.SentOn:F}",
                ConsoleColor.White);
        }
    }
}
