namespace OopDesignSnippets.Pipeline.Elements;

public abstract class Element
{
    public ProjectTask Task { get; }
    public int State { get; set; }

    protected Element(ProjectTask task) => Task = task;
    public abstract void Create();
    public abstract void Update();
    public abstract void Delete();
}