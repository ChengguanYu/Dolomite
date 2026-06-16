using dolomite_cli.app.Command;

namespace dolomite_cli.app;

public static class App
{
    public static void Run()
    {
        var cm = CommandManager.inst;
        cm.Run();
    }
}
