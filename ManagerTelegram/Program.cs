
namespace ManagerTelegram
{
  /// <summary>
  /// Запуск программы.
  /// </summary>
  internal class Program
  {
    /// <summary>
    /// Запуск Telegram бота.
    /// </summary>
    /// <returns>Task.</returns>
    async static Task Main()
    {
      await BotRealization.StatingBot();
    }
  }
}