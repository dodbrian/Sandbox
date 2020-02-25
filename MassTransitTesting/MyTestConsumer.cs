using System.Threading.Tasks;
using MassTransit;

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
