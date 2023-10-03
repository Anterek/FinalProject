using ManagerTelegram.EntitysModel;

namespace ManagerTelegram.EntitysAction
{
  /// <summary>
  /// Добавление сущностей.
  /// </summary>
  internal class AddEntitys
  {
    /// <summary>
    /// Добавление пользователя.
    /// </summary>
    /// <param name="NameUser">Имя пользователя.</param>
    /// <param name="UserId">Идентификатор пользователя.</param>
    public void AddUser(string NameUser, long UserId)
    {
      using (EntitysContext ec = new EntitysContext())
      {
        SelectEntitys selectEntitys = new SelectEntitys();
        if (ec.UsersDB.FirstOrDefault(p => p.IdentityNumber == UserId) == null)
        {
          ec.UsersDB.Add(new Users { UserName = NameUser, IdentityNumber = UserId });
          ec.SaveChanges();
        }
      }
    }

    /// <summary>
    /// Добавление задачи.
    /// </summary>
    /// <param name="taskName">Название задачи.</param>
    /// <param name="description">Описание задачи.</param>
    /// <param name="priority">Приоритет.</param>
    public void AddTask(string taskName, string description, string priority)
    {
      SelectEntitys selectEntitys = new SelectEntitys();
      using (EntitysContext ec = new EntitysContext())
      {
        ec.TasksDB.Add(new Tasks {Users = ec.UsersDB.FirstOrDefault(p => p.UserId == 1), Priority = ec.PriorityDB.FirstOrDefault(p => p.NamePriority == priority), Status = ec.StatusDB.FirstOrDefault(p => p.NameStatus == "Не распределен"), TaskName = taskName, Description = description});
        ec.SaveChanges();
      }
    }
  }
}
