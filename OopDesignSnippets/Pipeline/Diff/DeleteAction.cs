using OopDesignSnippets.Pipeline.Elements;

namespace OopDesignSnippets.Pipeline.Diff;

public class DeleteAction : DiffAction
{
    public DeleteAction(Element element) : base(element)
    {
    }

    public override void Apply() => Element.Delete();
}