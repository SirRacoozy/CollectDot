using CollectDot.CLI.Entities;

namespace CollectDot.CLI.Interfaces;

public interface ICDotExecutor
{
    void Init(string directory, GithubRepository repository);
    void Add(string filepath);
    void List();
    void Show(string filepath);
    void Remove(string filepath);
}