using OopDesignSnippets.Pipeline.Elements;

namespace OopDesignSnippets.Pipeline.Diff;

public class ActionFactory
{
    public DiffAction CreateAction(Element element) =>
        element.State switch
        {
            0 => new CreateAction(element),
            1 => new UpdateAction(element),
            2 => new DeleteAction(element),
            _ => throw new ArgumentOutOfRangeException()
        };
}