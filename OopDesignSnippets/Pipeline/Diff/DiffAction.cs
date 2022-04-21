using OopDesignSnippets.Pipeline.Elements;

namespace OopDesignSnippets.Pipeline.Diff;

public abstract class DiffAction
{
    protected Element Element { get; }

    protected DiffAction(Element element) => Element = element;

    public abstract void Apply();
}