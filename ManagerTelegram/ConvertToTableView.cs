using ManagerTelegram.EntitysModel;
using System.Diagnostics;
using System.Reflection;

namespace ManagerTelegram
{
  /// <summary>
  /// Конвертирорвание списка задач в таблицу.
  /// </summary>
  internal class ConvertToTableView
  {
    /// <summary>
    /// Ширина таблицы.
    /// </summary>
    public int tableWidth = 100;

    /// <summary>
    /// Ширина ячейки таблицы.
    /// </summary>
    public int cellWidth = 18;

    /// <summary>
    /// Конвертирование списка задач.
    /// </summary>
    /// <param name="listTasks">Список задач.</param>
    /// <returns>Таблица.</returns>
    public string ConversionTasks(string listTasks)
    {
      string line = new string('-', tableWidth);
      string tableTasks = string.Empty;
      string[] rows = listTasks.Split('*');
      string[][] cell = new string[rows.Length][];
      for (int i = 0; i < rows.Length; i++)
      {
        cell[i] = rows[i].Split('|');
      }
      for (int i = 0; i < cell.Length - 1; i++)
      {
        tableTasks += line + Environment.NewLine;
        tableTasks += RowTasks(cell[i]) + Environment.NewLine;
        
      }
      return tableTasks + line;
    }

    /// <summary>
    /// Форматирование строки.
    /// </summary>
    /// <param name="tasklist">Ячейка таблицы.</param>
    /// <returns>Отформатированная строка.</returns>
    public string RowTasks(string[] cell)
    {
      string row = "|";
      for (int i = 0; i < cell.Length; i++)
      {
        row += Centre(cell[i], cellWidth) + "|";
      }
      return row ;
    }

    /// <summary>
    /// Форматирование ячейки.
    /// </summary>
    /// <param name="cell">Ячейка таблицы.</param>
    /// <param name="cellWidth">Ширина ячейки</param>
    /// <returns>Отформатированная ячейка таблицы.</returns>
    public string Centre(string cell, int cellWidth)
    {
      if (cell.Length > cellWidth)
        cell = cell.Substring(0, cellWidth - 3) + "...";
      if (string.IsNullOrEmpty(cell))
        return new string(' ', cellWidth);
      else
        return new string(' ', cellWidth - cell.Length) + cell + new string(' ', cellWidth - cell.Length);
    }
  }
}
