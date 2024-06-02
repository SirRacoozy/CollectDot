using System.CommandLine;
using CollectDot.CLI.Entities;
using CollectDot.CLI.Interfaces;

namespace CollectDot.CLI.CommandLine;

internal class CommandLineParser
{
    #region - needs -

    private readonly string[] _Arguments;
    private RootCommand _RootCommand;

    #endregion

    #region - ctor -

    internal CommandLineParser(string[] arguments, ICDotExecutor executor)
    {
        _Arguments = arguments;
        __InitCommands(executor);
        
    }
    
    #endregion

    #region - public methods -

    internal void ParseArguments()
    {
        if (_RootCommand is null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The root command couldn't be found.");
            Console.ResetColor();

            return;
        }

        _ = _RootCommand.Invoke(_Arguments);
    }

    #endregion

    #region - private methods -

    private void __InitCommands(ICDotExecutor executor)
    {
        _RootCommand = new RootCommand("Starts the interactive version of cdot.");
        _RootCommand.AddCommand(__InitInitCommand(executor));
        _RootCommand.AddCommand(__InitAddCommand(executor));
        _RootCommand.AddCommand(__InitListCommand(executor));
        _RootCommand.AddCommand(__InitShowCommand(executor));
        _RootCommand.AddCommand(__InitRemoveCommand(executor));
    }

    private Command __InitInitCommand(ICDotExecutor executor)
    {
        var command = new Command("init", "Initiates the cdot system.");
        command.AddAlias("i");

        var directoryArgument =
            new Argument<string>("Directory", "The directory that is used as the base of the cdot system.");
        var githubUserArgument =
            new Argument<string>("Github username", "The GitHub username to use for synchronization.");
        var githubRepoArgument = new Argument<string>("Github repository name", "The name of the GitHub repository.");

        command.AddArgument(directoryArgument);
        command.AddArgument(githubUserArgument);
        command.AddArgument(githubRepoArgument);

        command.SetHandler((directory, githubUser, githubRepo) =>
        {
            executor.Init(directory, new GithubRepository(githubUser, githubRepo));
        }, directoryArgument, githubUserArgument, githubRepoArgument);
        
        return command;
    }

    private Command __InitAddCommand(ICDotExecutor executor)
    {
        var command = new Command("add", "Adds a file to the cdot system.");
        command.AddAlias("a");
        
        var fileArgument = new Argument<string>("File", "The file to add to the cdot system.");

        command.AddArgument(fileArgument);
        
        command.SetHandler(executor.Add, fileArgument);

        return command;
    }

    private Command __InitListCommand(ICDotExecutor executor)
    {
        var command = new Command("list", "Lists all config files.");
        command.AddAlias("l");
        
        command.SetHandler(executor.List);

        return command;
    }

    private Command __InitShowCommand(ICDotExecutor executor)
    {
        var command = new Command("show", "Shows the content of a config file.");
        command.AddAlias("s");

        var fileArgument = new Argument<string>("File", "The file to show from the cdot system.");

        command.AddArgument(fileArgument);
        
        command.SetHandler(executor.Show, fileArgument);

        return command;
    }

    private Command __InitRemoveCommand(ICDotExecutor executor)
    {
        var command = new Command("remove", "Removes the file from the cdot system.");
        command.AddAlias("r");

        var fileArgument = new Argument<string>("File", "The file to remove from the cdot system.");
        
        command.AddArgument(fileArgument);
        
        command.SetHandler(executor.Remove, fileArgument);

        return command;
    }

    #endregion
}