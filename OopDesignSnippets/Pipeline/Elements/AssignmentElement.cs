using OopDesignSnippets.Pipeline.Data;
using OopDesignSnippets.Pipeline.Entities;

namespace OopDesignSnippets.Pipeline.Elements;

public class AssignmentElement : Element
{
    private readonly Repository<Assignment> _assignmentRepository;

    public AssignmentElement(ProjectTask task, Repository<Assignment> assignmentRepository) : base(task) =>
        _assignmentRepository = assignmentRepository;

    public override void Create()
    {
        var entity = new Assignment
        {
            Id = Task.GUID,
            Name = Task.Name,
        };

        _assignmentRepository.Add(entity);
    }

    public override void Update()
    {
        var entity = _assignmentRepository.Get(Task.GUID);
        entity.Name = Task.Name;
    }

    public override void Delete()
    {
        var entity = _assignmentRepository.Get(Task.GUID);
        _assignmentRepository.Delete(entity);
    }
}