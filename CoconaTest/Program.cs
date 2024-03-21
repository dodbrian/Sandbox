using Cocona;

var builder = CoconaApp.CreateBuilder();
var app = builder.Build();

app.AddCommand((string name) => Console.WriteLine($"Test {name}"));

app.Run();
