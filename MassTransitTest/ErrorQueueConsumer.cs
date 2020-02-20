using System;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.RabbitMqTransport.Contexts;
using Newtonsoft.Json;
using Sandbox.Common;

namespace MassTransitTest
{
    public class ErrorQueueConsumer : IConsumer<IFailingMessage>
    {
        public async Task Consume(ConsumeContext<IFailingMessage> context)
        {
            var receiveContext = (RabbitMqReceiveContext)context.ReceiveContext;

            await ColoredConsole.WriteLineAsync(
                $"Failed message received: {JsonConvert.SerializeObject(context.Message, Formatting.Indented)}\n" +
                $"IsFaulted: {receiveContext.IsFaulted}\n" +
                $"IsRedelivered: {receiveContext.Redelivered}\n" +
                $"Exchange: {receiveContext.Exchange}",
                ConsoleColor.Red);
        }
    }
}
