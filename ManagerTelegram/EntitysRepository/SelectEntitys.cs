using ManagerTelegram.EntitysModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerTelegram.EntitysAction
{
  /// <summary>
  /// Выборка сущностей.
  /// </summary>
  internal class SelectEntitys
  {
    public string SelectOneTasksAtStatus(int taskId, string currentStatus)
    {
      using (EntitysContext ec = new EntitysContext())
      {
        string tasksList = string.Empty;
        var tasks = from task in ec.TasksDB
                    join user in ec.UsersDB on task.UserId equals user.UserId
                    join status in ec.StatusDB on task.StatusId equals status.StatusId
                    join priority in ec.PriorityDB on task.PriorityId equals priority.PriorityId
                    where task.TaskId == taskId && status.NameStatus == currentStatus
                    select new
                    {
                      TaskID = task.TaskId,
                      Name = task.TaskName,
                      Description = task.Description,
                      Priority = priority.NamePriority
                    };
        foreach (var task in tasks)
        {
          tasksList += $"Задача №: {task.TaskID}\n" +
                       $"Название: {task.Name}\n" +
                       $"Описание: {task.Description}\n" +
                       $"Приоритет: {task.Priority}";
        }
        return tasksList;
      }
    }

    public string SelectTask(int taskId)
    {
      string taskList = string.Empty;
      return taskList;
    }

    /// <summary>
    /// Выборка задач по статусу.
    /// </summary>
    /// <param name="currentStatus">Статус.</param>
    /// <returns></returns>
    public string SelectTasksByStatus(string currentStatus)
    {
      using (EntitysContext ec = new EntitysContext())
      {
        string tasksList = string.Empty;
        var tasks = from task in ec.TasksDB
                    join priority in ec.PriorityDB on task.PriorityId equals priority.PriorityId
                    where task.Status!.NameStatus == currentStatus
                    select new 
                    { 
                      TaskID = task.TaskId, 
                      Name = task.TaskName, 
                      Priority = priority.NamePriority
                    };
        foreach (var task in tasks)
        {
          tasksList += task.TaskID + "|" + task.Name + "|" + task.Priority + "*";
        }
        //return tasksList;
        ConvertToTableView convertToTable = new ConvertToTableView();
        return convertToTable.ConversionTasks(tasksList);
      }
    }

    /// <summary>
    /// Выборка задач по пользователю.
    /// </summary>
    /// <param name="currentUser">Пользователь.</param>
    /// <returns></returns>
    public string SelectTasksByUser(long currentUser, string currentStatus)
    {
      using (EntitysContext ec = new EntitysContext())
      {
        string tasksList = string.Empty;
        var tasks = from task in ec.TasksDB
                    join user in ec.UsersDB on task.UserId equals user.UserId
                    join priority in ec.PriorityDB on task.PriorityId equals priority.PriorityId
                    join status in ec.StatusDB on task.StatusId equals status.StatusId
                    where  user.IdentityNumber == currentUser && status.NameStatus == currentStatus
                    select new
                    {
                      TaskID = task.TaskId,
                      Name = task.TaskName,
                      Priority = priority.NamePriority
                    };
        foreach (var task in tasks)
        {
          tasksList += task.TaskID + " " + task.Name + " " + task.Priority + Environment.NewLine;
        }
        return tasksList;
      }
    }

    /// <summary>
    /// Выборка статусов.
    /// </summary>
    /// <returns>Список статусов.</returns>
    public List<Status> SelectStatus()
    {
      using (EntitysContext ec = new EntitysContext())
      {
        return ec.StatusDB.ToList();
      }
    }
  }
}

