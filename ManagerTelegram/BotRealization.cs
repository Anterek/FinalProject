using Telegram.Bot.Types.Enums;
using Telegram.Bot;
using Telegram.Bot.Types;
using ManagerTelegram.Bot;
using ManagerTelegram.BotMenu;
using ManagerTelegram.BotPage;

namespace ManagerTelegram
{
  /// <summary>
  /// Бот.
  /// </summary>
  internal class BotRealization
  {
    /// <summary>
    /// Запуск бота.
    /// </summary>
    /// <returns>Task.</returns>
    async public static Task StatingBot()
    {
      TelegramBotClient client = new TelegramBotClient("6485197502:AAFWZi0blKR_eDWKZuPTgluFry8oqUbY7rA");
      client.StartReceiving(Update, Error);
      Console.WriteLine("Program start...");
      await Task.Delay(int.MaxValue);
    }

    /// <summary>
    /// Обработчик входящих сообщений.
    /// </summary>
    /// <param name="botClient">Клиент для работы с Telegram Bot Api.</param>
    /// <param name="update">Входящее сообщение.</param>
    /// <param name="token">Уникальный ключ.</param>
    /// <returns>Task.</returns>
    async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
    {
      if (StatusMenu.PlaceMenu == Place.Main)
      {
        Main mainMenu = new Main();
        if (update.Type == UpdateType.Message)
          await mainMenu.MessageTextProcessingAsync(update, botClient, token);
        else if (update.Type == UpdateType.CallbackQuery)
          await mainMenu.InLineKeyBoardProcessingAsync(update, botClient, token);
      }

      else if (StatusMenu.PlaceMenu == Place.NewTasks)
      {
        TasksAtNew newTasksMenu = new TasksAtNew();
        if (update.Type == UpdateType.Message)
          await newTasksMenu.MessageTextProcessingAsync(update, botClient, token);
        else if (update.Type == UpdateType.CallbackQuery)
          await newTasksMenu.InLineKeyBoardProcessingAsync(update, botClient, token);
      }

      else if (StatusMenu.PlaceMenu == Place.ViewTask)
      {
        ViewingTasksAtNew viewingNewTask = new ViewingTasksAtNew();
        if (update.Type == UpdateType.Message)
          await viewingNewTask.MessageTextProcessingAsync(update, botClient, token);
        else if (update.Type == UpdateType.CallbackQuery)
          await viewingNewTask.InLineKeyBoardProcessingAsync(update, botClient, token);
      }

      else if (StatusMenu.PlaceMenu == Place.OwnTasks)
      {
        TasksAtOwn ownTask = new TasksAtOwn();
        if (update.Type == UpdateType.Message)
          await ownTask.MessageTextProcessingAsync(update, botClient, token);
        else if (update.Type == UpdateType.CallbackQuery)
          await ownTask.InLineKeyBoardProcessingAsync(update, botClient, token);
      }

      else if (StatusMenu.PlaceMenu == Place.ViewOwnTask)
      {
        ViewingTaskAtOwn viewingTaskAtOwn = new ViewingTaskAtOwn();
        if (update.Type == UpdateType.Message)
          await viewingTaskAtOwn.MessageTextProcessingAsync(update, botClient, token);
        else if (update.Type == UpdateType.CallbackQuery)
          await viewingTaskAtOwn.InLineKeyBoardProcessingAsync(update, botClient, token);
      }

      else if (StatusMenu.PlaceMenu == Place.WorkTasks)
      {
        TasksAtWork taskAtWork = new TasksAtWork();
        if (update.Type == UpdateType.Message)
          await taskAtWork.MessageTextProcessingAsync(update, botClient, token);
        else if (update.Type == UpdateType.CallbackQuery)
          await taskAtWork.InLineKeyBoardProcessingAsync(update, botClient, token);
      }

      else if (StatusMenu.PlaceMenu == Place.ViewWorkTask)
      {
        ViewingTaskAtWork viewingTaskAtWork = new ViewingTaskAtWork();
        if (update.Type == UpdateType.Message)
          await viewingTaskAtWork.MessageTextProcessingAsync(update, botClient, token);
        else if (update.Type == UpdateType.CallbackQuery)
          await viewingTaskAtWork.InLineKeyBoardProcessingAsync(update, botClient, token);
      }

      else if (StatusMenu.PlaceMenu == Place.CloseTasks)
      {
        TasksAtClose tasksAtClose = new TasksAtClose();
        if (update.Type == UpdateType.Message)
          await tasksAtClose.MessageTextProcessingAsync(update, botClient, token);
        else if (update.Type == UpdateType.CallbackQuery)
          await tasksAtClose.InLineKeyBoardProcessingAsync(update, botClient, token);
      }

      else if (StatusMenu.PlaceMenu == Place.ViewCloseTask)
      {
        ViewingTaskAtClose viewingTaskAtClose = new ViewingTaskAtClose();
        if (update.Type == UpdateType.Message)
          await viewingTaskAtClose.MessageTextProcessingAsync(update, botClient, token);
        else if (update.Type == UpdateType.CallbackQuery)
          await viewingTaskAtClose.InLineKeyBoardProcessingAsync(update, botClient, token);
      }
    }

    /// <summary>
    /// Обработчик ошибок.
    /// </summary>
    /// <param name="botClient">Клиент для работы с Telegram Bot Api.</param>
    /// <param name="exception">Исключение.</param>
    /// <param name="token">Уникальный ключ.</param>
    /// <returns>Task.</returns>
    private static Task Error(ITelegramBotClient botClient, Exception exception, CancellationToken token)
    {
      Console.WriteLine($"Ошибка программы {exception.Message}");
      return Task.CompletedTask;
    }
  }
}
