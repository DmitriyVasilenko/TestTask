namespace Application.Dtos;

public abstract class EntityDtoBase
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public virtual Guid Id { get; set; }
    public EntityDtoBase()
    {
        Id = Guid.NewGuid();
    } 
}
