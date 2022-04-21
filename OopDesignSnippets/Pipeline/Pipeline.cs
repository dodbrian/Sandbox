using OopDesignSnippets.Pipeline.Diff;

namespace OopDesignSnippets.Pipeline;

public class Pipeline
{
    private readonly DiffBuilder _builder;

    public Pipeline(DiffBuilder builder) => _builder = builder;

    public void Run()
    {
        var tasks = Array.Empty<ProjectTask>();
        var diff = _builder.CreateDiff(tasks);

        foreach (var action in diff)
            action.Apply();
    }
}