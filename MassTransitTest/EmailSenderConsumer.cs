using MassTransit;
using System;
using System.Threading.Tasks;

namespace MassTransitTest
{
    public class EmailSenderConsumer : IConsumer<ISendEmail>
    {
        public async Task Consume(ConsumeContext<ISendEmail> context)
        {
            await Console.Out.WriteLineAsync(
                $"EmailSenderConsumer: Sending email to {context.Message.Recipient} at {context.Message.Email}");

            await context.Publish<IEmailSent>(new
            {
                context.Message.Email,
                SentOn = DateTime.UtcNow
            });
        }
    }
}
