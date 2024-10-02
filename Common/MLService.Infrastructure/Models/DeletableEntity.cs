namespace MLService.Infrastructure.Models;

/// <summary>
/// Сущность с возможность удаления
/// </summary>
public class DeletableEntity : Entity
{
    /// <summary>
    /// Удаленый объект
    /// </summary>
    public bool IsDeleted { get; protected set; } 

    /// <summary>
    /// Удалить объект
    /// </summary>
    public void Delete()
    {
        if (IsDeleted) throw new Exception("Этот объект уже удалена");
        IsDeleted = true;
    }

    /// <summary>
    /// Востановить объект
    /// </summary>
    public void Restore()
    {
        if (!IsDeleted) throw new Exception("Этот объект не удален");
        IsDeleted = false;
    }


}
