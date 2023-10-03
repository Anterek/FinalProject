using System.ComponentModel.DataAnnotations;

namespace ManagerTelegram.EntitysModel
{
  /// <summary>
  /// Задачи.
  /// </summary>
  internal class Tasks
  {
    /// <summary>
    /// Идентификатор.
    /// </summary>
    [Key]
    public int TaskId { get; set; }

    /// <summary>
    /// Название задачи.
    /// </summary>
    public string? TaskName { get; set; }

    /// <summary>
    /// Описание задачи.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Внешний ключ.
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Пользователь.
    /// </summary>

    public Users? Users { get; set; }

    /// <summary>
    /// Внешний ключ.
    /// </summary>
    public int StatusId { get; set; }

    /// <summary>
    /// Статус.
    /// </summary>
    public Status? Status { get; set; }

    /// <summary>
    /// Внешний ключ.
    /// </summary>
    public int PriorityId { get; set; }

    /// <summary>
    /// Приоритет.
    /// </summary>
    public Priority? Priority { get; set; }
  }
}
