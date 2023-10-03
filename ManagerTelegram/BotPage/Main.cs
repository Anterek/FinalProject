using ManagerTelegram.EntitysAction;
using ManagerTelegram.Interface;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ManagerTelegram.Bot
{
  /// <summary>
  /// Главное страница.
  /// </summary>
  internal class Main : IBotMessage
  {
    /// <summary>
    /// Обработка сообщения в виде текста.
    /// </summary>
    /// <param name="update">Входящее сообщение.</param>
    /// <param name="botClient">Клиент для работы с Telegram Bot Api.</param>
    /// <param name="token">Уникальный ключ.</param>
    /// <returns>Task.</returns>
    async public Task MessageTextProcessingAsync(Update update, ITelegramBotClient botClient, CancellationToken token)
    {
      var chatID = update.Message!.Chat.Id;
      ButtonsMap buttonMap = new ButtonsMap();
      switch (update.Message!.Text)
      {
        case "/start":
          AddEntitys addEntitys = new AddEntitys();
          Temporary.IdentityNumber = update.Message!.From!.Id!;
          addEntitys.AddUser(update.Message?.From?.FirstName!, Temporary.IdentityNumber);
          await botClient.SendTextMessageAsync(chatID!, $"Привет {update.Message!.From!.FirstName}", replyMarkup: buttonMap.GetMainMenu(), cancellationToken: token);
          break;
        default:
          await botClient.SendTextMessageAsync(chatID!, $"Для работы c ботом необходимо написать '/start' или нажмите", cancellationToken: token);
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
    async public Task InLineKeyBoardProcessingAsync(Update update, ITelegramBotClient botClient, CancellationToken token)
    {
      var chatID = update.CallbackQuery!.Message!.Chat.Id;
      ButtonsMap buttonMap = new ButtonsMap();
      SelectEntitys selectEntitys = new SelectEntitys();
      switch (update.CallbackQuery?.Data)
      {
        case "keyTasks":
          StatusMenu.PlaceMenu = Place.NewTasks;
          await botClient.SendTextMessageAsync(chatID, $"Задачи:\n{selectEntitys.SelectTasksByStatus("Не распределен")}", replyMarkup: buttonMap.GetTasksMenu(), cancellationToken: token);
          break;
        case "keyTasksAtWork":
          StatusMenu.PlaceMenu = Place.WorkTasks;
          await botClient.SendTextMessageAsync(chatID, $"Задачи:\n{selectEntitys.SelectTasksByStatus("В работе")}", replyMarkup: buttonMap.GetTasksAtWorkMenu(), cancellationToken: token);
          break;
        case "keyTasksAtClose":
          StatusMenu.PlaceMenu = Place.CloseTasks;
          await botClient.SendTextMessageAsync(chatID, $"Задачи:\n{selectEntitys.SelectTasksByStatus("Закрыт")}", replyMarkup: buttonMap.GetTasksAtCloseMenu(), cancellationToken: token);
          break;
        case "keyTasksAtOwn":
          StatusMenu.PlaceMenu = Place.OwnTasks;
          await botClient.SendTextMessageAsync(chatID, $"Задачи:\n{selectEntitys.SelectTasksByUser(Temporary.IdentityNumber, "В работе")}", replyMarkup: buttonMap.GetTasksAtWorkMenu(), cancellationToken: token);
          break;
      }
    }
  }
}
