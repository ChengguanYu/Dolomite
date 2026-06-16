namespace dolomite_cli.App.Command;

public class CommandManager
{   
    private static readonly Lazy<CommandManager> _inst = new(()=> new CommandManager());
    public static CommandManager inst => _inst.Value;
    
    private CommandType _commandType;
    private string[] _commandParam;
    
    CommandManager()
    {
        var args = Environment.GetCommandLineArgs();
        if (args.Length < 2)
        {
            var validCommands = string.Join(", ", Enum.GetNames<CommandType>());
            throw new ArgumentException($"No command provided. Valid commands: {validCommands}");
        }
        _commandType = ParseCommandType(args[1]);
        _commandParam = args.Skip(2).ToArray();
    }

    private static CommandType ParseCommandType(string command)
    {
        if (!Enum.TryParse<CommandType>(command, ignoreCase: true, out var commandType))
        {
            var validCommands = string.Join(", ", Enum.GetNames<CommandType>());
            throw new ArgumentException($"Invalid command: {command}. Valid commands: {validCommands}");
        }
        return commandType;
    }
    
    public void Run()
    {
        // 一次运行只会执行一个指令
        switch (_commandType)
        {
            case CommandType.Start:
                Start start = new Start(_commandParam);
                start.Execute();
                break;
            case CommandType.Stop:
                Stop stop = new Stop(_commandParam);
                stop.Execute();
                break;
        }
    }
}