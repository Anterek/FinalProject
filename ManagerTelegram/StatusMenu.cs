namespace ManagerTelegram
{
  /// <summary>
  /// Статусы создания задачи.
  /// </summary>
  public enum StatusCreateTask
  {
    Main,
    NameTask,
    DescriptionTask,
    Priority
  }

  /// <summary>
  /// Статус меню.
  /// </summary>
  public enum Place
  {
    Main,
    NewTasks,
    ViewTask,
    OwnTasks,
    CloseTasks,
    WorkTasks,
    ViewWorkTask,
    ViewCloseTask,
    ViewOwnTask
  }

  /// <summary>
  /// Навигационное меню.
  /// </summary>
  internal class StatusMenu
  {
    /// <summary>
    /// Статус создания задачи.
    /// </summary>
    public static StatusCreateTask StatusCreate { get; set; } = StatusCreateTask.Main;

    /// <summary>
    /// Статус меню.
    /// </summary>
    public static Place PlaceMenu { get; set; } = Place.Main;
  }
}
