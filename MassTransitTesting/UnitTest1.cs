using System.Linq;
using FluentAssertions;
using MassTransit.Testing;
using Xunit;

namespace MassTransitTesting
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            var harness = new InMemoryTestHarness();
            var consumerHarness = harness.Consumer<MyTestConsumer>();

            await harness.Start();

            try
            {
                await harness.InputQueueSendEndpoint.Send<IMessage>(new { });

                Assert.True(harness.Consumed.Select<IMessage>().Any());
                harness.Consumed.Select<IMessage>().Should().NotBeEmpty();
                
                Assert.True(consumerHarness.Consumed.Select<IMessage>().Any());
                consumerHarness.Consumed.Select<IMessage>().Should().NotBeEmpty();
            }
            finally
            {
                await harness.Stop();
            }
        }
    }
}
