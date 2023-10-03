using ManagerTelegram.EntitysAction;
using ManagerTelegram.Interface;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ManagerTelegram.BotMenu
{
  /// <summary>
  /// Страница просмотра выбранной задачи с статусом "Закрыта".
  /// </summary>
  internal class ViewingTaskAtClose : IBotMessage
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
      SelectEntitys selectEntitys = new SelectEntitys();
      ButtonsMap buttonsMap = new ButtonsMap();
      Temporary.CurrentTask = int.Parse(update.Message.Text!);
      if (selectEntitys.SelectOneTasksAtStatus(Temporary.CurrentTask, "Закрыт") != string.Empty)
        await botClient.SendTextMessageAsync(chatID!, $"{selectEntitys.SelectOneTasksAtStatus(Temporary.CurrentTask, "Закрыт")}", replyMarkup: buttonsMap.GetViewTaskMenu(), cancellationToken: token);
      else
      {
        Temporary.CurrentTask = 0;
        StatusMenu.PlaceMenu = Place.CloseTasks;
        await botClient.SendTextMessageAsync(chatID, $"Пожалуйста, выберите задачу из списка:\n{selectEntitys.SelectTasksByStatus("Закрыт")}", replyMarkup: buttonsMap.GetTasksAtCloseMenu(), cancellationToken: token);
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
      SelectEntitys selectEntitys = new SelectEntitys();
      ButtonsMap buttonsMap = new ButtonsMap();
      switch (update.CallbackQuery.Data)
      {
        case "keyCloseMenu":
          Temporary.CurrentTask = 0;
          StatusMenu.PlaceMenu = Place.CloseTasks;
          await botClient.SendTextMessageAsync(chatID, $"Задачи:\n{selectEntitys.SelectTasksByStatus("Закрыт")}", replyMarkup: buttonsMap.GetTasksAtCloseMenu(), cancellationToken: token);
          break;
      }
    }
  }
}
