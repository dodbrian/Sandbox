namespace EFNullProjection;

public record Craft
{
    public Guid Id { get; init; }
    public string? Name { get; init; }
    public Guid? LabelId { get; init; }
    public Label? Label { get; init; }
}
