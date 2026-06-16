using dolomite_cli.App.Util;

namespace dolomite_cli.App.Command;

public enum CommandType
{
    Start,
    Stop,
}

public abstract class Command
{
    protected CommandType _type;
    protected List<FlagItem> _flags = new();

    protected Command(CommandType type)
    {
        _type = type;
    }

    // 子类需要实现 Execute 方法来执行指令逻辑
    public abstract void Execute();
    // 注册指令参数
    protected void RegisterFlag(FlagDefinition def)
    {
        FlagRegistry.Register(_type, def);
    }

    protected FlagItem? GetFlag(string name)
    {
        return _flags.FirstOrDefault(f => f.Name == name);
    }

    /// <summary>
    /// 解析命令行参数，返回当前 command 适用的 flag 列表
    /// </summary>
    protected List<FlagItem> ParseFlags(string[] args)
    {
        var applicableFlags = FlagRegistry.GetForCommand(_type).ToList();
        // 建立 flag 和可匹配参数的映射表
        var aliasMap = new Dictionary<string, FlagDefinition>();
        foreach (var def in applicableFlags)
        {
            foreach (var alias in def.Aliases)
            {
                aliasMap[alias] = def;
            }
        }

        var result = new List<FlagItem>();
        FlagDefinition? currentFlag = null;
        // 遍历所有args ， 查看是否有可以匹配的
        for (int i = 0; i < args.Length; i++)
        {
            string arg = args[i];

            if (arg.StartsWith('-'))
            {
                if (!aliasMap.TryGetValue(arg, out var flagDef))
                {
                    throw new ArgumentException($"Unknown flag: {arg}");
                }

                currentFlag = flagDef;

                bool hasNext = i + 1 < args.Length;
                bool nextIsFlag = hasNext && args[i + 1].StartsWith('-');

                if (!hasNext || nextIsFlag)
                {
                    // flag 参数为空，检查是否必须提供
                    if (currentFlag.Required)
                    {
                        throw new ArgumentException($"Flag '{arg}' requires a value");
                    }
                    
                    result.Add(new FlagItem
                    {
                        Name = currentFlag.Name,
                        Param = "",
                        ParamType = currentFlag.ParamType
                    });
                    currentFlag = null;
                }
            }
            else
            {
                if (currentFlag == null)
                {
                    throw new ArgumentException($"Unexpected argument without flag: {arg}");
                }

                result.Add(new FlagItem
                {
                    Name = currentFlag.Name,
                    Param = arg,
                    ParamType = currentFlag.ParamType
                });
                currentFlag = null;
            }
        }

        return result;
    }
}