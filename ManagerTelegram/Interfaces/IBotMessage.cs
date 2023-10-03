using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ManagerTelegram.Interface
{
  /// <summary>
  /// Интерфейс обрабоки входящих сообщений.
  /// </summary>
  internal interface IBotMessage
  {
    /// <summary>
    /// Обработка сообщения в виде текста.
    /// </summary>
    /// <param name="update">Входящее сообщение.</param>
    /// <param name="botClient">Клиент для работы с Telegram Bot Api.</param>
    /// <param name="token">Уникальный ключ.</param>
    /// <returns>Task.</returns>
    Task MessageTextProcessingAsync(Update update, ITelegramBotClient botClient, CancellationToken token);

    /// <summary>
    /// Обработка сообщения в виде нажатия на встроенную клавиатуру.
    /// </summary>
    /// <param name="update">Входящее сообщение.</param>
    /// <param name="botClient">Клиент для работы с Telegram Bot Api.</param>
    /// <param name="token">Уникальный ключ.</param>
    /// <returns>Task.</returns>
    Task InLineKeyBoardProcessingAsync(Update update, ITelegramBotClient botClient, CancellationToken token);
  }
}
