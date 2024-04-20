using Confluent.Kafka;

var producerConfig = new ProducerConfig
{
    BootstrapServers = "localhost:9092,localhost:9093,localhost:9094",
};

using var producer = new ProducerBuilder<string, double>(producerConfig).Build();

const string stateString = "AK,AL,AZ,AR,CA,CO,CT,DE,FL,GA," +
                           "HI,ID,IL,IN,IA,KS,KY,LA,ME,MD," +
                           "MA,MI,MN,MS,MO,MT,NE,NV,NH,NJ," +
                           "NM,NY,NC,ND,OH,OK,OR,PA,RI,SC," +
                           "SD,TN,TX,UT,VT,VA,WA,WV,WI,WY";

var stateArray = stateString.Split(',');
const string topic = "myorders";

for (var i = 0; i < 25000; i++)
{
    var key = stateArray[(int)Math.Floor(Random.Shared.NextDouble() * 50)];
    var value = Math.Floor(Random.Shared.NextDouble() * (10000 - 10 + 1) + 10);

    Console.WriteLine($"Sending message with key {key} to Kafka");

    var deliveryResult = await producer.ProduceAsync(
        topic,
        new Message<string, double>
        {
            Key = key,
            Value = value
        });

    Console.WriteLine(key);
    Console.WriteLine(value);
    Console.WriteLine(deliveryResult.Offset.ToString());
    Console.WriteLine(deliveryResult.Partition.ToString());

    await Task.Delay(1000);
}

producer.Flush();

Console.WriteLine("Successfully produced messages to " + topic + " topic");
