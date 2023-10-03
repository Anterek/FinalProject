using ManagerTelegram.EntitysAction;
using ManagerTelegram.Interface;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ManagerTelegram.BotMenu
{
  /// <summary>
  /// Страница просмотра выбранной задачи.
  /// </summary>
  internal class ViewingTasksAtNew : IBotMessage
  {
    public long ID;
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
      SelectEntitys selectEntitys = new SelectEntitys();
      ButtonsMap buttonsMap = new ButtonsMap();
      Temporary.CurrentTask = int.Parse(update.Message.Text!);
      if (selectEntitys.SelectOneTasksAtStatus(Temporary.CurrentTask, "Не распределен") != string.Empty)
        await botClient.SendTextMessageAsync(chatID!, $"{selectEntitys.SelectOneTasksAtStatus(Temporary.CurrentTask, "Не распределен")}", replyMarkup: buttonsMap.GetViewTaskMenu(), cancellationToken: token);
      else
      {
        StatusMenu.PlaceMenu = Place.NewTasks;
        Temporary.CurrentTask = 0;
        await botClient.SendTextMessageAsync(chatID, $"Пожалуйста, выберите задачу из списка:\n{selectEntitys.SelectTasksByStatus("Не распределен")}", replyMarkup: buttonsMap.GetTasksMenu(), cancellationToken: token);
      }
      return;
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
      SelectEntitys selectEntitys = new SelectEntitys();
      switch (update.CallbackQuery.Data)
      {
        case "keyTakeTask":
          UpdateEntitys updateEntitys = new UpdateEntitys();
          StatusMenu.PlaceMenu = Place.NewTasks;
          updateEntitys.UpdateTaskByUser(Temporary.CurrentTask, "В работе", Temporary.IdentityNumber);
          Temporary.CurrentTask = 0;
          await botClient.SendTextMessageAsync(chatID, $"Задача взята\n{selectEntitys.SelectTasksByStatus("Не распределен")}", replyMarkup: buttonsMap.GetTasksMenu(), cancellationToken: token);
          break;
        case "keyRemoveTask":
          DeleteEntitys deleteEntitys = new DeleteEntitys();
          deleteEntitys.DeleteTask(Temporary.CurrentTask);
          Temporary.CurrentTask = 0;
          StatusMenu.PlaceMenu = Place.NewTasks;
          await botClient.SendTextMessageAsync(chatID, $"Задача удалена", replyMarkup: buttonsMap.GetTasksMenu(), cancellationToken: token);
          break;
        case "keyCloseMenu":
          StatusMenu.PlaceMenu = Place.NewTasks;
          Temporary.CurrentTask = 0;
          await botClient.SendTextMessageAsync(chatID, $"Задачи:\n{selectEntitys.SelectTasksByStatus("Не распределен")}", replyMarkup: buttonsMap.GetTasksMenu(), cancellationToken: token);
          break;
      }
    }
  }
}
