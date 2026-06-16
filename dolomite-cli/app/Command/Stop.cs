using dolomite_cli.App.Util;

namespace dolomite_cli.App.Command;

/// <summary>
/// Stop 命令的 flag 标识
/// </summary>
public static class StopFlags
{
    public const string Env = "env";
}

public class Stop : Command
{
    public Stop(string[] args) : base(CommandType.Stop)
    {
        RegisterFlag(new FlagDefinition
        {
            Name = StopFlags.Env,
            Aliases = ["-e", "--e"],
            ParamType = typeof(string),
            Description = "Environment name"
        });

        _flags = ParseFlags(args);
    }

    public override void Execute()
    {
        var env = GetFlag(StopFlags.Env);
        Logger.Info($"Stop Command with env: {env?.Param ?? "default"}");
    }
}