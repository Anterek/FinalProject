namespace ManagerTelegram
{
  /// <summary>
  /// Временные файлы.
  /// </summary>
  internal class Temporary
  {
    /// <summary>
    /// Текущая задача.
    /// </summary>
    public static int CurrentTask { get; set; } = 0;

    /// <summary>
    /// Название задачи.
    /// </summary>
    public static string TaskName { get; set; } = String.Empty;

    /// <summary>
    /// Описание задачи.
    /// </summary>
    public static string Description { get; set; } = String.Empty;

    /// <summary>
    /// Пользователь.
    /// </summary>
    public static long IdentityNumber { get; set; }
  }
}
