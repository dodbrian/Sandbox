using OopDesignSnippets.Pipeline.Elements;

namespace OopDesignSnippets.Pipeline.Diff;

public class UpdateAction : DiffAction
{
    public UpdateAction(Element element) : base(element)
    {
    }

    public override void Apply() => Element.Update();
}