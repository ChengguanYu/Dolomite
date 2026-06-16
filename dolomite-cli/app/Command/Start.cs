using dolomite_cli.App.Util;

namespace dolomite_cli.App.Command;

enum StartFlag
{
    Env
}

public class Start:Command
{
    private Dictionary<StartFlag,string> _paramater = new Dictionary<StartFlag, string>();
    public Start(string[] args) : base(CommandType.Start)
    {
        //解释参数
    }
    public override void Execute()
    {
        // 实现处理逻辑
        Logger.Info("Start Command");
    }
}