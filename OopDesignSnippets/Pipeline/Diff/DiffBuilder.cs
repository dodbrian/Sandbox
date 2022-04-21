using OopDesignSnippets.Pipeline.Elements;

namespace OopDesignSnippets.Pipeline.Diff;

public class DiffBuilder
{
    private readonly ElementFactory _elementFactory;
    private readonly ActionFactory _actionFactory;

    public DiffBuilder(ElementFactory elementFactory, ActionFactory actionFactory)
    {
        _elementFactory = elementFactory;
        _actionFactory = actionFactory;
    }

    public IEnumerable<DiffAction> CreateDiff(IEnumerable<ProjectTask> tasks)
    {
        var elements = tasks.Select(task => _elementFactory.CreateElement(task));
        var actions = elements.Select(element => _actionFactory.CreateAction(element));

        return actions;
    }
}