using dolomite_cli.App.Command;

namespace dolomite_cli.App;

public static class App
{
    public static void Run()
    {
        var cm = CommandManager.inst;
        cm.Run();
    }
}
