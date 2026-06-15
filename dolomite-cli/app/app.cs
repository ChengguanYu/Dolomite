namespace dolomite_cli;
using Microsoft.Extensions.Configuration;

public class App
{
    static void Main(string[] args)
    {
        IConfiguration configuration = new AppConfigure(args).Build();

        string? greeting = configuration.GetValue<string>("Greeting");
        Console.WriteLine(greeting ?? "Hello, World!");
    }
}
