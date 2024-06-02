using CollectDot.CLI.CommandLine;
using CollectDot.CLI.Executor;

public class Program
{
    public static void Main(string[] args)
    {
        Console.Title = "CollectDot";
        new CommandLineParser(args, CDotExecutorFactory.GetCDotExecutor()).ParseArguments();
    }
}