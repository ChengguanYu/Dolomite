using Serilog;
using Serilog.Events;

namespace dolomite_cli.app.util;

/// <summary>
/// 全局日志工具类，封装 Serilog 提供统一的日志接口。
/// 用法：Logger.Init() 初始化后，在任意位置调用 Logger.Info/Warn/Error 等静态方法。
/// </summary>
public static class Logger
{
    private const string OutputTemplate = "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}";

    /// <summary>
    /// 初始化日志系统。应在程序入口处调用且仅调用一次。
    /// </summary>
    /// <param name="logDir">日志文件目录，默认 "logs"</param>
    /// <param name="minimumLevel">最低日志级别，默认 Information</param>
    public static void Init(string logDir = "logs", LogEventLevel minimumLevel = LogEventLevel.Information)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Is(minimumLevel)
            .WriteTo.Console(outputTemplate: OutputTemplate)
            .WriteTo.File(
                path: Path.Combine(logDir, "app-.txt"),
                rollingInterval: Serilog.RollingInterval.Day,
                retainedFileCountLimit: 30,
                outputTemplate: OutputTemplate)
            .CreateLogger();
    }

    /// <summary>
    /// 关闭并刷新日志，确保所有缓冲内容写入磁盘。应在程序退出前调用。
    /// </summary>
    public static void CloseAndFlush()
    {
        Log.CloseAndFlush();
    }

    public static void Debug(string message) => Log.Debug(message);
    public static void Debug(string message, params object[] args) => Log.Debug(message, args);

    public static void Info(string message) => Log.Information(message);
    public static void Info(string message, params object[] args) => Log.Information(message, args);

    public static void Warn(string message) => Log.Warning(message);
    public static void Warn(string message, params object[] args) => Log.Warning(message, args);

    public static void Error(string message) => Log.Error(message);
    public static void Error(string message, params object[] args) => Log.Error(message, args);
    public static void Error(Exception ex, string message) => Log.Error(ex, message);
    public static void Error(Exception ex, string message, params object[] args) => Log.Error(ex, message, args);

    public static void Fatal(Exception ex, string message) => Log.Fatal(ex, message);
    public static void Fatal(Exception ex, string message, params object[] args) => Log.Fatal(ex, message, args);

    /// <summary>
    /// 执行业务逻辑，自动捕获异常并转为 Fatal 日志，退出前刷新缓冲区。
    /// </summary>
    /// <param name="action">业务逻辑委托</param>
    /// <returns>0 表示成功，1 表示异常退出</returns>
    public static int Run(Action action)
    {
        try
        {
            action();
            return 0;
        }
        catch (Exception ex)
        {
            Fatal(ex, "Application terminated unexpectedly");
            return 1;
        }
        finally
        {
            CloseAndFlush();
        }
    }
}
