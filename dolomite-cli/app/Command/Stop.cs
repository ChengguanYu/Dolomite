using dolomite_cli.app.util;

namespace dolomite_cli.app.Command;
// enum StopFlag
// {
//     
// }
public class Stop:Command
{
    // private Dictionary<StartFlag,string> _paramater = new Dictionary<StartFlag, string>();
    public Stop(string[] args) : base(CommandType.Stop)
    {
        //解释参数
    }
    public override void Execute()
    {
        // 实现处理逻辑
        Logger.Info("Stop Command");
    }
}