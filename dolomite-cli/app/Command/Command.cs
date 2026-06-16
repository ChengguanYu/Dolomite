namespace dolomite_cli.app.Command;

public enum CommandType
{
    Start,
    Stop,
}

public abstract class Command
{
    protected CommandType _type;
    protected Command(CommandType type)
    {
        _type = type;
    }
    // 子类需要实现
    public abstract void Execute();
}