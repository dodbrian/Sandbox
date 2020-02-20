using System;
using System.Threading.Tasks;
using MassTransit;
using Sandbox.Common;

namespace MassTransitTest
{
    public class EmailSenderConsumer : IConsumer<ISendEmail>
    {
        public async Task Consume(ConsumeContext<ISendEmail> context)
        {
            await ColoredConsole.WriteLineAsync(
                $"EmailSenderConsumer: Sending email to {context.Message.Recipient} at {context.Message.Email}",
                ConsoleColor.Yellow);

            await context.Publish<IEmailSent>(new
            {
                context.Message.Email,
                SentOn = DateTime.UtcNow
            });
        }
    }
}
