using ManagerTelegram.EntitysAction;
using ManagerTelegram.Interface;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ManagerTelegram.BotPage
{
  internal class TasksAtOwn : IBotMessage
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
      //var chatID = update.Message!.Chat.Id;
      //SelectEntitys selectEntitys = new SelectEntitys();
      //await botClient.SendTextMessageAsync(chatID!, $"Ваши задачи:\n{selectEntitys.SelectTasksByUser(Temporary.IdentityNumber, "В работе")}", cancellationToken: token);
      var chatID = update.Message!.Chat.Id;
      ButtonsMap buttonMap = new ButtonsMap();
      SelectEntitys selectEntitys = new SelectEntitys();
      switch (update.Message!.Text)
      {
        default:
          await botClient.SendTextMessageAsync(chatID!, $"Кажется вы ввели что-то, но оно не правильно или не нужно сейчас\n{selectEntitys.SelectTasksByUser(Temporary.IdentityNumber, "В работе")}", replyMarkup: buttonMap.GetTasksAtCloseMenu(), cancellationToken: token);
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
      SelectEntitys selectEntitys = new SelectEntitys();
      switch (update.CallbackQuery.Data)
      {
        case "keyViewWorkTask":
          StatusMenu.PlaceMenu = Place.ViewOwnTask;
          await botClient.SendTextMessageAsync(chatID, $"Введите номер задачи для просмотра", replyMarkup: buttonsMap.GetCancelButton(), cancellationToken: token);
          break;
        case "keyCloseMenu":
          StatusMenu.PlaceMenu = Place.Main;
          await botClient.SendTextMessageAsync(chatID, $"Главное меню", replyMarkup: buttonsMap.GetMainMenu(), cancellationToken: token);
          break;
      }
    }
  }
}
