using CollectDot.CLI.Entities;
using CollectDot.CLI.Interfaces;

namespace CollectDot.CLI.Executor;

public class CDotTestExecutor : ICDotExecutor
{
    public void Init(string directory, GithubRepository repository)
    {
        Console.WriteLine($"dir: {directory}\nuser: {repository.username}\nrepo: {repository.repo}");
        Console.ReadKey();
    }

    public void Add(string filepath)
    {
        Console.WriteLine($"filepath: {filepath}");
        Console.ReadKey();
    }

    public void List()
    {
        Console.WriteLine("LIST");
        Console.ReadKey();
    }

    public void Show(string filepath)
    {
        Console.WriteLine($"filepath: {filepath}");
        Console.ReadKey();
    }

    public void Remove(string filepath)
    {
        Console.WriteLine($"filepath: {filepath}");
        Console.ReadKey();
    }
}