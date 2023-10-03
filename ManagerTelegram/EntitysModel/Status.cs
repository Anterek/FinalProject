using System.ComponentModel.DataAnnotations;

namespace ManagerTelegram.EntitysModel
{
  /// <summary>
  /// Статусы.
  /// </summary>
  internal class Status
  {
    /// <summary>
    /// Идентификатор.
    /// </summary>
    [Key]
    public int StatusId { get; set; }

    /// <summary>
    /// Название статуса.
    /// </summary>
    public string? NameStatus { get; set; }

    /// <summary>
    /// Идентификатор задачи.
    /// </summary>
    public List<Tasks> Tasks { get; set; } = new();
  }
}
