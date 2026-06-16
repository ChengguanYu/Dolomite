// namespace dolomite_cli.util;
//
// public class Command
// {
//     public Command(
//         CommandType type,
//         string parameter,
//         )
//     {
//     }
// }
//
// // using Command = Dictionary<CommandType, string>;
//
// public enum CommandType
// {
//     Start,
//     Stop,
//     Env,
// }
// public class CommandParser
// {
//     private static readonly Lazy<CommandParser> _instance = new(()=>new CommandParser());
//     public static CommandParser Instance => _instance.Value;
//     private List<Command> commandQueue= new List<Command>();
//
//     private CommandParser()
//     {   
//         
//     }
// }