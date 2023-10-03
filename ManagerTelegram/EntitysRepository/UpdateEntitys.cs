using ManagerTelegram.EntitysModel;

namespace ManagerTelegram.EntitysAction
{
  /// <summary>
  /// Обновление сущностей.
  /// </summary>
  internal class UpdateEntitys
  {
    /// <summary>
    /// Обновление пользователя в задаче.
    /// </summary>
    /// <param name="taskId">Идентификатор задачи.</param>
    /// <param name="currentStatus">Статус.</param>
    /// <param name="userId">Идентификатор пользователя.</param>
    public void UpdateTaskByUser(int taskId, string currentStatus, long userId)
    {
      using(EntitysContext ec = new EntitysContext())
      {
        var task = ec.TasksDB.FirstOrDefault(t => t.TaskId == taskId);
        var user = ec.UsersDB.FirstOrDefault(t => t.IdentityNumber == userId);
        var status = ec.StatusDB.FirstOrDefault(t => t.NameStatus == currentStatus);
        if(task != null && user != null)
        {
          task.Users = user;
          task.Status = status;
          ec.SaveChanges();
        }
      }
    }

    /// <summary>
    /// Обновление статуса задачи.
    /// </summary>
    /// <param name="taskId">Идентификатор задачи.</param>
    /// <param name="currentStatus">Статус.</param>
    public void UpdateTaskByStatus(int taskId, string currentStatus)
    {
      using (EntitysContext ec = new EntitysContext())
      {
        var task = ec.TasksDB.FirstOrDefault(t => t.TaskId == taskId);
        var status = ec.StatusDB.FirstOrDefault(t => t.NameStatus == currentStatus);
        if (task != null)
        {
          task.Status = status;
          ec.SaveChanges();
        }
      }
    }
  }
}
