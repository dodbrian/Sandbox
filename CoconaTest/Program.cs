using System.Globalization;
using Cocona;
using CoconaTest.Localization;

var builder = CoconaApp.CreateBuilder();
var app = builder.Build();

Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");
Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");

app.AddCommand((string name) => Console.WriteLine(Strings.TestName, name));

app.Run();
