using dolomite_cli.App.Command;

namespace dolomite_cli.App.Util;

/// <summary>
/// Flag 定义：描述一个命令行参数的元数据
/// </summary>
public class FlagDefinition
{
    /// <summary>
    /// flag 唯一标识，如 "env", "port"
    /// </summary>
    public string Name { get; init; } = "";
    
    /// <summary>
    /// 命令行别名，如 ["-e", "--env"]
    /// </summary>
    public string[] Aliases { get; init; } = [];
    
    /// <summary>
    /// 参数值类型
    /// </summary>
    public Type ParamType { get; init; } = typeof(string);
    
    /// <summary>
    /// 描述信息
    /// </summary>
    public string? Description { get; init; }
    
    /// <summary>
    /// 是否必须提供参数值（不允许为空）
    /// </summary>
    public bool Required { get; init; } = false;
}

/// <summary>
/// 解析后的 flag 实例
/// </summary>
public class FlagItem
{
    /// <summary>
    /// flag 标识
    /// </summary>
    public string Name { get; init; } = "";
    
    /// <summary>
    /// 参数值（始终为字符串）
    /// </summary>
    public string Param { get; init; } = "";
    
    /// <summary>
    /// 参数值类型
    /// </summary>
    public Type ParamType { get; init; } = typeof(string);
}

/// <summary>
/// 全局 flag 注册表，按 CommandType 分组存储
/// </summary>
public static class FlagRegistry
{
    private static readonly Dictionary<CommandType, List<FlagDefinition>> _flags = new();

    public static void Register(CommandType command, FlagDefinition def)
    {
        if (!_flags.ContainsKey(command))
            _flags[command] = new List<FlagDefinition>();
        _flags[command].Add(def);
    }

    public static IEnumerable<FlagDefinition> GetForCommand(CommandType command)
    {
        return _flags.GetValueOrDefault(command) ?? Enumerable.Empty<FlagDefinition>();
    }
}
