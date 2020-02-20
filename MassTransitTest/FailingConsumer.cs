using System;
using System.Threading.Tasks;
using MassTransit;
using Newtonsoft.Json;
using Sandbox.Common;

namespace MassTransitTest
{
    public class FailingConsumer
        : IConsumer<IFailingMessage>,
        IConsumer<Fault<IFailingMessage>>
    {
        public Task Consume(ConsumeContext<IFailingMessage> context)
        {
            throw new Exception("This consumer intentionally throws an exception");
        }

        public async Task Consume(ConsumeContext<Fault<IFailingMessage>> context)
        {
            await ColoredConsole.WriteLineAsync(
                $"Intercepted exception: {JsonConvert.SerializeObject(context.Message, Formatting.Indented)}",
                ConsoleColor.Green);
        }
    }
}
