namespace dolomite_cli;
using Microsoft.Extensions.Configuration;

public class AppConfigure
{
    private readonly IConfiguration _configuration;

    public AppConfigure(string[] args)
    {
        _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .AddEnvironmentVariables()
            .AddCommandLine(args, new Dictionary<string, string>
            {
                { "-g", "Greeting" },
                { "-Greeting", "Greeting" },
            })
            .Build();
    }

    public IConfiguration Build() => _configuration;
}
