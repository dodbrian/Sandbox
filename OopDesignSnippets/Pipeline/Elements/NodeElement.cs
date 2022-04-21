using OopDesignSnippets.Pipeline.Data;
using OopDesignSnippets.Pipeline.Entities;

namespace OopDesignSnippets.Pipeline.Elements;

public class NodeElement : Element
{
    private readonly Repository<ProjectNode> _nodeRepository;

    public NodeElement(ProjectTask task, Repository<ProjectNode> nodeRepository) : base(task) =>
        _nodeRepository = nodeRepository;

    public override void Create()
    {
        var entity = new ProjectNode
        {
            Id = Task.GUID,
            Name = Task.Name,
        };

        _nodeRepository.Add(entity);
    }

    public override void Update()
    {
        var entity = _nodeRepository.Get(Task.GUID);
        entity.Name = Task.Name;
    }

    public override void Delete()
    {
        var entity = _nodeRepository.Get(Task.GUID);
        _nodeRepository.Delete(entity);
    }
}