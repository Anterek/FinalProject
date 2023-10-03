using System.ComponentModel.DataAnnotations;

namespace ManagerTelegram.EntitysModel
{
  /// <summary>
  /// Пользователи.
  /// </summary>
  internal class Users
  {
    /// <summary>
    /// Идентификатор.
    /// </summary>
    [Key]
    public int UserId { get; set; }

    /// <summary>
    /// Идентификационный номер пользователя Telegram.
    /// </summary>
    public long IdentityNumber { get; set; }

    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public string? UserName { get; set; }

    /// <summary>
    /// Идентификатор задачи.
    /// </summary>
    public List<Tasks> Tasks { get; set; } = new();
  }
}
