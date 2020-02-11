using System.Threading.Tasks;
using MassTransit;
using MassTransitTest;

namespace MassTransitTesting
{
    public class MyTestConsumer : IConsumer<IMessage>
    {
        public Task Consume(ConsumeContext<IMessage> context)
        {
            return Task.CompletedTask;
        }
    }
}
