using OopDesignSnippets.Pipeline.Elements;

namespace OopDesignSnippets.Pipeline.Diff;

public class CreateAction : DiffAction
{
    public CreateAction(Element element) : base(element)
    {
    }

    public override void Apply() => Element.Create();
}