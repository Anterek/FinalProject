using System.ComponentModel.DataAnnotations;

namespace ManagerTelegram.EntitysModel
{
  /// <summary>
  /// Приоритет задачи.
  /// </summary>
  internal class Priority
  {
    /// <summary>
    /// Идентификатор.
    /// </summary>
    [Key]
    public int PriorityId { get; set; }

    /// <summary>
    /// Название приоритета.
    /// </summary>
    public string? NamePriority { get; set; }

    /// <summary>
    /// Идентификатор задачи.
    /// </summary>
    public List<Tasks> Tasks { get; set; } = new(); 
  }
}
