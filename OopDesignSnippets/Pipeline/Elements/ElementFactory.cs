using OopDesignSnippets.Pipeline.Data;
using OopDesignSnippets.Pipeline.Entities;

namespace OopDesignSnippets.Pipeline.Elements;

public class ElementFactory
{
    private readonly Repository<ProjectNode> _nodeRepository;
    private readonly Repository<Assignment> _assignmentRepository;

    public ElementFactory(Repository<ProjectNode> nodeRepository, Repository<Assignment> assignmentRepository)
    {
        _nodeRepository = nodeRepository;
        _assignmentRepository = assignmentRepository;
    }

    public Element CreateElement(ProjectTask task) =>
        task.Type switch
        {
            0 => new NodeElement(task, _nodeRepository),
            1 => new AssignmentElement(task, _assignmentRepository),
            _ => throw new ArgumentOutOfRangeException()
        };
}