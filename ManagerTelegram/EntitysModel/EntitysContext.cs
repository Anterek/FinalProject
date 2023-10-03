using Microsoft.EntityFrameworkCore;

namespace ManagerTelegram.EntitysModel
{
  /// <summary>
  /// Корнтекст взаимодействия с БД.
  /// </summary>
  internal class EntitysContext : DbContext
  {
    /// <summary>
    /// Набор объектов Tasks.
    /// </summary>
    public DbSet<Tasks> TasksDB { get; set; } = null!;

    /// <summary>
    /// Набор объектов Priority.
    /// </summary>
    public DbSet<Priority> PriorityDB { get; set; } = null!;

    /// <summary>
    /// Набор объектов Users.
    /// </summary>
    public DbSet<Users> UsersDB { get; set; } = null!;

    /// <summary>
    /// Набор объектов Status.
    /// </summary>
    public DbSet<Status> StatusDB { get; set; } = null!;

    /// <summary>
    /// Конфигурация подключения к БД.
    /// </summary>
    /// <param name="optionsBuilder"> Параметр подключения.</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite(@"Data Source = " + Environment.CurrentDirectory + @"\TaskManager.db;");
    }

    /// <summary>
    /// Первоначальные настройки.
    /// </summary>
    /// <param name="modelBuilder"> Построитель модели.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Tasks>().HasOne(u => u.Users).WithMany(c => c.Tasks).HasForeignKey(u => u.UserId);
      modelBuilder.Entity<Priority>().HasData(new Priority {PriorityId = 1, NamePriority = "Высокая" }, new Priority {PriorityId = 2, NamePriority = "Средняя" }, new Priority {PriorityId = 3, NamePriority = "Низкая" });
      modelBuilder.Entity<Status>().HasData(new Status {StatusId = 1, NameStatus = "В работе" }, new Status {StatusId = 2, NameStatus = "Не распределен" }, new Status { StatusId = 3, NameStatus = "Закрыт"});
      modelBuilder.Entity<Users>().HasData(new Users {UserId = 1, IdentityNumber = 0, UserName = "Default" });
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    public EntitysContext()
    {
      Database.EnsureCreated();
    }
  }
}
