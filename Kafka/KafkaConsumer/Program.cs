using Confluent.Kafka;

var consumerConfig = new ConsumerConfig
{
    BootstrapServers = "localhost:9092,localhost:9093,localhost:9094",
    GroupId = "consumer",
};

using var consumer = new ConsumerBuilder<string, double>(consumerConfig).Build();
consumer.Subscribe("myorders");

while (true)
{
    var consumeResult = consumer.Consume();
    Console.WriteLine($"Consumed message with key {consumeResult.Message.Key} and value {consumeResult.Message.Value}");
}
