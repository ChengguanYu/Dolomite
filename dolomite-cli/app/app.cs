using dolomite_cli.app.Command;
using dolomite_cli.app.util;

namespace dolomite_cli;

public class App
{
    static int Main(string[] args)
    {
        Logger.Init();
        try
        {
            var cm = CommandManager.inst;
            cm.Run();
            return 0;
        }
        catch (Exception ex)
        {
            Logger.Fatal(ex, "Application terminated unexpectedly");
            return 1;
        }
        finally
        {
            Logger.CloseAndFlush();
        }
    }
}
