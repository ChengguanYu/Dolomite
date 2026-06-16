using dolomite_cli.App.Util;

namespace dolomite_cli.App.Command;

/// <summary>
/// Start 命令的 flag 标识（可选，用于类型安全）
/// </summary>
public static class StartFlags
{
    public const string Env = "env";
}

/// <summary>
/// Start 命令：启动服务
/// 用法: dolomite-cli Start [flags]
/// 示例: dolomite-cli Start -e master
/// </summary>
public class Start : Command
{
    public Start(string[] args) : base(CommandType.Start)
    {
        RegisterFlag(new FlagDefinition
        {
            Name = StartFlags.Env,
            Aliases = ["-e", "--e"],
            ParamType = typeof(string),
            Description = "Environment name"
        });

        _flags = ParseFlags(args);
    }

    public override void Execute()
    {
        var env = GetFlag(StartFlags.Env);
        Logger.Info($"Start Command with env: {env?.Param ?? "default"}");
    }
}
