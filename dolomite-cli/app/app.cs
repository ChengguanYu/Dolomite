using dolomite_cli.app.Command;

namespace dolomite_cli;
using Microsoft.Extensions.Configuration;

public class App
{
    static void Main(string[] args)
    {
        var cm = CommandManager.inst;
        cm.Run();
    }
}
