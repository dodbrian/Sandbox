namespace OopDesignSnippets.Pipeline.Data;

public abstract class Repository<T>
{
    public abstract void Add(T entity);
    public abstract T Get(Guid guid);
    public abstract void Delete(T entity);
}