using ManagerTelegram.EntitysAction;
using ManagerTelegram.Interface;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ManagerTelegram.BotMenu
{
  /// <summary>
  /// Страница с новыми задачами.
  /// </summary>
  internal class TasksAtNew : IBotMessage
  {
    /// <summary>
    /// Обработка сообщения в виде текста.
    /// </summary>
    /// <param name="update">Входящее сообщение.</param>
    /// <param name="botClient">Клиент для работы с Telegram Bot Api.</param>
    /// <param name="token">Уникальный ключ.</param>
    /// <returns>Task.</returns>
    public async Task MessageTextProcessingAsync(Update update, ITelegramBotClient botClient, CancellationToken token)
    {
      var chatID = update!.Message!.Chat.Id!;
      ButtonsMap buttonsMap = new ButtonsMap();
      if (StatusMenu.StatusCreate == StatusCreateTask.NameTask)
      {
        Temporary.TaskName = update.Message!.Text!;
        StatusMenu.StatusCreate = StatusCreateTask.DescriptionTask;
        await botClient.SendTextMessageAsync(chatID, $"Введите описание задачи", replyMarkup: buttonsMap.GetCancelButton(), cancellationToken: token);
      }
      else if (StatusMenu.StatusCreate == StatusCreateTask.DescriptionTask)
      {
        Temporary.Description = update.Message!.Text!;
        StatusMenu.StatusCreate = StatusCreateTask.Priority;
        await botClient.SendTextMessageAsync(chatID, $"Выберите приоритет задачи", replyMarkup: buttonsMap.GetPriorityButtons(), cancellationToken: token);
      }
      ButtonsMap buttonMap = new ButtonsMap();
      SelectEntitys selectEntitys = new SelectEntitys();
      switch (update.Message!.Text)
      {
        default:
          await botClient.SendTextMessageAsync(chatID!, $"Кажется вы ввели что-то, но оно не правильно или не нужно сейчас\n{selectEntitys.SelectTasksByStatus("Не распределен")}", replyMarkup: buttonMap.GetTasksMenu(), cancellationToken: token);
          break;
      }
    }

    /// <summary>
    /// Обработка сообщения в виде нажатия на встроенную клавиатуру.
    /// </summary>
    /// <param name="update">Входящее сообщение.</param>
    /// <param name="botClient">Клиент для работы с Telegram Bot Api.</param>
    /// <param name="token">Уникальный ключ.</param>
    /// <returns>Task.</returns>
    public async Task InLineKeyBoardProcessingAsync(Update update, ITelegramBotClient botClient, CancellationToken token)
    {
      var chatID = update.CallbackQuery!.Message!.Chat.Id;
      ButtonsMap buttonsMap = new ButtonsMap();
      AddEntitys addEntitys = new AddEntitys();
      SelectEntitys selectEntitys = new SelectEntitys();
      switch (update.CallbackQuery!.Data)
      {
        case "keyViewTask":
          StatusMenu.PlaceMenu = Place.ViewTask;
          await botClient.SendTextMessageAsync(chatID, $"Введите номер задачи для просмотра", replyMarkup: buttonsMap.GetCancelButton(), cancellationToken: token);
          break;
        case "keyCreateTask":
          StatusMenu.StatusCreate = StatusCreateTask.NameTask;
          await botClient.SendTextMessageAsync(chatID, $"Введите название задачи", replyMarkup: buttonsMap.GetCancelButton(), cancellationToken: token);
          break;
        case "keyCloseMenu":
          StatusMenu.PlaceMenu = Place.Main;
          await botClient.SendTextMessageAsync(chatID, $"Главное меню", replyMarkup: buttonsMap.GetMainMenu(), cancellationToken: token);
          break;
        case "keyCancel":
          StatusMenu.StatusCreate = StatusCreateTask.Main;
          await botClient.SendTextMessageAsync(chatID, $"Добавление задачи отменено", replyMarkup: buttonsMap.GetTasksMenu(), cancellationToken: token);
          break;
        case "keyHighPriority":
          StatusMenu.StatusCreate = StatusCreateTask.Main;
          StatusMenu.PlaceMenu = Place.NewTasks;
          addEntitys.AddTask(Temporary.TaskName!, Temporary.Description!, "Высокая");
          await botClient.SendTextMessageAsync(chatID, $"Задача добавлена\n{selectEntitys.SelectTasksByStatus("Не распределен")}", replyMarkup: buttonsMap.GetTasksMenu(), cancellationToken: token);
          break;
        case "keyMediumPriority":
          StatusMenu.StatusCreate = StatusCreateTask.Main;
          StatusMenu.PlaceMenu = Place.NewTasks;
          addEntitys.AddTask(Temporary.TaskName!, Temporary.Description!, "Средняя");
          await botClient.SendTextMessageAsync(chatID, $"Задача добавлена\n{selectEntitys.SelectTasksByStatus("Не распределен")}", replyMarkup: buttonsMap.GetTasksMenu(), cancellationToken: token);
          break;
        case "keyLowPriority":
          StatusMenu.StatusCreate = StatusCreateTask.Main;
          StatusMenu.PlaceMenu = Place.NewTasks;
          addEntitys.AddTask(Temporary.TaskName!, Temporary.Description!, "Низкая");
          await botClient.SendTextMessageAsync(chatID, $"Задача добавлена\n{selectEntitys.SelectTasksByStatus("Не распределен")}", replyMarkup: buttonsMap.GetTasksMenu(), cancellationToken: token);
          break;
      }
    }
  }
}
