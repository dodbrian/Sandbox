using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Sandbox.Common;

namespace MassTransitTest
{
    public static class Program
    {
        public static async Task Main()
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                var host = sbc.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                sbc.ReceiveEndpoint(host, "test_queue", ep =>
                {
                    ep.Handler<YourMessage>(async context =>
                    {
                        await Console.Out.WriteLineAsync($"Handler 1: Received: {context.Message.Text}, address: {context.ReceiveContext.InputAddress}");
                    });

                    ep.Handler<YourMessageReceived>(async context =>
                    {
                        await Console.Out.WriteLineAsync($"Handler 2: Confirmation received: {context.Message.ReceivedText}, " +
                                                         $"address: {context.ReceiveContext.InputAddress}");
                    });

                    ep.Consumer<FailingConsumer>();
                });

                sbc.ReceiveEndpoint(host, "test_queue_error", ep =>
                {
                    ep.Consumer<ErrorQueueConsumer>();
                });

                sbc.ReceiveEndpoint(host, "second_test_queue", ep =>
                {
                    ep.Handler<YourMessage>(async context =>
                    {
                        await Console.Out.WriteLineAsync($"Handler 3: Received: {context.Message.Text}, address: {context.ReceiveContext.InputAddress}");

                        await context.Publish(new YourMessageReceived
                        {
                            ReceivedText = $"Received message: {context.Message.Text}"
                        });
                    });
                });

                sbc.ReceiveEndpoint(host, "email_sender_queue", ep =>
                {
                    ep.Consumer<EmailSenderConsumer>();
                });

                sbc.ReceiveEndpoint(host, "notification_queue", ep =>
                {
                    ep.Handler<YourMessage>(async context =>
                    {
                        await Console.Out.WriteLineAsync($"Handler 4: Received: {context.Message.Text}, address: {context.ReceiveContext.InputAddress}");
                    });

                    ep.Consumer<NotificationConsumer>();
                });
            });

            bus.Start();

            await bus.Publish(new YourMessage { Text = "Publish Hi" });

            var sendEndpoint = await bus.GetSendEndpoint(new Uri("rabbitmq://localhost/test_queue"));
            await sendEndpoint.Send(new YourMessage { Text = "Send Hahahaha" });

            var emailSenderEndpoint = await bus.GetSendEndpoint(new Uri("rabbitmq://localhost/email_sender_queue"));
            await emailSenderEndpoint.Send<ISendEmail>(new { Email = "some@test.de", Recipient = "Good Boy" });

            await ColoredConsole.WriteLineAsync("Sending failing message...", ConsoleColor.Cyan);
            await bus.Publish<IFailingMessage>(new { Id = Guid.NewGuid() });

            //Console.WriteLine("Press any key to exit");
            //Console.ReadLine();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            bus.Stop();
        }
    }
}
