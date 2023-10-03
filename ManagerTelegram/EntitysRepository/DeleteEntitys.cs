using ManagerTelegram.EntitysModel;

namespace ManagerTelegram.EntitysAction
{
  /// <summary>
  /// Удаление сущностей.
  /// </summary>
  internal class DeleteEntitys
  {
    /// <summary>
    /// Удаление задачи.
    /// </summary>
    /// <param name="taskId">Идентификатор задачи.</param>
    public void DeleteTask(int taskId)
    {
      using (EntitysContext ec = new EntitysContext())
      {
        var task = ec.TasksDB.FirstOrDefault(t => t.TaskId == taskId);
        if(task != null)
        {
          ec.TasksDB.Remove(task);
          ec.SaveChanges();
        }
      }
    }
  }
}
