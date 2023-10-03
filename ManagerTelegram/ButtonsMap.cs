using Telegram.Bot.Types.ReplyMarkups;

namespace ManagerTelegram
{
  /// <summary>
  /// Определение меню Telegram бота.
  /// </summary>
  internal class ButtonsMap
  {
    /// <summary>
    /// Главное меню.
    /// </summary>
    /// <returns>Кнопки.</returns>
    public IReplyMarkup GetMainMenu()
    {
      return new InlineKeyboardMarkup(
        new[]
        {
          new[]
          {
            InlineKeyboardButton.WithCallbackData(text: "Новые задачи", callbackData: "keyTasks"),
          },
          new[]
          {
            InlineKeyboardButton.WithCallbackData(text: "В работе", callbackData: "keyTasksAtWork"),
            InlineKeyboardButton.WithCallbackData(text: "Завершенные", callbackData: "keyTasksAtClose"),
          },
          new[]
          {
            InlineKeyboardButton.WithCallbackData(text: "Мои задачи", callbackData: "keyTasksAtOwn")
          }
        });
    }

    /// <summary>
    /// Меню нераспределенных задач.
    /// </summary>
    /// <returns>Кнопки.</returns>
    public IReplyMarkup GetTasksMenu()
    {
      return new InlineKeyboardMarkup(
        new[]
        {
          new[]
          {
            InlineKeyboardButton.WithCallbackData(text: "Выбрать задачу", callbackData: "keyViewTask"),
          },
          new[]
          {
            InlineKeyboardButton.WithCallbackData(text: "Создать задачу", callbackData: "keyCreateTask"),
          },
          new[]
          {
            InlineKeyboardButton.WithCallbackData(text: "Выход", callbackData: "keyCloseMenu")
          }});
    }

    /// <summary>
    /// Меню просмотра выбранной задачи.
    /// </summary>
    /// <returns>Кнопки.</returns>
    public IReplyMarkup GetViewTaskMenu()
    {
      return new InlineKeyboardMarkup(
        new[]
        {
          new[]
          {
            InlineKeyboardButton.WithCallbackData(text: "Взять задачу", callbackData: "keyTakeTask"),
            InlineKeyboardButton.WithCallbackData(text: "Удалить задачу", callbackData: "keyRemoveTask")
          },
          new[]
          {
            InlineKeyboardButton.WithCallbackData(text: "Выход", callbackData: "keyCloseMenu")
          }});
    }

    /// <summary>
    /// Меню задач с сатусом "В работе".
    /// </summary>
    /// <returns>Кнопки.</returns>
    public IReplyMarkup GetTasksAtWorkMenu()
    {
      return new InlineKeyboardMarkup(
        new[]
        {
          new[]
          {
            InlineKeyboardButton.WithCallbackData(text: "Просмотр задачи", callbackData: "keyViewWorkTask")
          },
          new[]
          {
            InlineKeyboardButton.WithCallbackData(text: "Выход", callbackData: "keyCloseMenu")
          }});
    }

    /// <summary>
    /// Меню выбранной задачи со статусом "В работе".
    /// </summary>
    /// <returns>Кнопки.</returns>
    public IReplyMarkup GetViewTaskAtWorkMenu()
    {
      return new InlineKeyboardMarkup(
        new[]
        {
          new[]
          {
            InlineKeyboardButton.WithCallbackData(text: "Закрыть задачу", callbackData: "keyCloseTask")
          },
          new[]
          {
            InlineKeyboardButton.WithCallbackData(text: "Выход", callbackData: "keyCloseMenu")
          }});
    }

    /// <summary>
    /// Меню задач с стасуом "Закрытые".
    /// </summary>
    /// <returns>Кнопки.</returns>
    public IReplyMarkup GetTasksAtCloseMenu()
    {
      return new InlineKeyboardMarkup(
        new[]
        {
          new[]
          {
            InlineKeyboardButton.WithCallbackData(text: "Просмотр задачи", callbackData: "keyViewCloseTask"),
          },
          new[]
          {
            InlineKeyboardButton.WithCallbackData(text: "Выход", callbackData: "keyCloseMenu")
          }});
    }

    /// <summary>
    /// Меню выбранной задачи со статусом "Закрытые".
    /// </summary>
    /// <returns>Кнопки.</returns>
    public IReplyMarkup GetViewTaskAtCloseMenu()
    {
      return new InlineKeyboardMarkup(
        new[]
        {
            InlineKeyboardButton.WithCallbackData(text: "Выход", callbackData: "keyCloseMenu")
        });
    }

    /// <summary>
    /// Кнопка отмены.
    /// </summary>
    /// <returns>Кнопка.</returns>
    public IReplyMarkup GetCancelButton()
    {
      return new InlineKeyboardMarkup(InlineKeyboardButton.WithCallbackData(text: "Отменить действия", callbackData: "keyCancel"));
    }

    /// <summary>
    /// Меню приоритетов задачи.
    /// </summary>
    /// <returns>Кнопки.</returns>
    public IReplyMarkup GetPriorityButtons()
    {
      return new InlineKeyboardMarkup(
        new[]
        {
            InlineKeyboardButton.WithCallbackData(text: "Высокая", callbackData: "keyHighPriority"),
            InlineKeyboardButton.WithCallbackData(text: "Средняя", callbackData: "keyMediumPriority"),
            InlineKeyboardButton.WithCallbackData(text: "Низкая", callbackData: "keyLowPriority")
        });
    }
  }
}
