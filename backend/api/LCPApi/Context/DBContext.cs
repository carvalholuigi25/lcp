using Microsoft.EntityFrameworkCore;
using LCPApi.Models;

namespace LCPApi.Context;

public class DBContext : DbContext {
    protected readonly IConfiguration Configuration;
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderCustomer> OrdersCustomers { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<ProductSubscription> ProductsSubscriptions { get; set; }
    public DbSet<SubscriptionKey> SubscriptionsKeys { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProjectTask> ProjectTasks { get; set; }
    public DbSet<ProjectTaskType> ProjectTasksTypes { get; set; }
    public DbSet<ProjectPhase> ProjectsPhases { get; set; }
    public DbSet<ProductProject> ProductsProjects { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<FeedbackComment> FeedbacksComments { get; set; }
    public DbSet<Department> Departments { get; set; }

    public DBContext(DbContextOptions<DBContext> options, IConfiguration configuration) : base(options) 
    { 
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var defdbmode = Configuration["defaultDBMode"]!.ToString() ?? "SQL Server";
        var dbconstrsqlsrv = Configuration.GetConnectionString("LCPDBSqlServer");
        var dbconstrmysql = Configuration.GetConnectionString("LCPDBMySQL");
        var dbconstrsqllite = Configuration.GetConnectionString("LCPDBSqlLite");

        if (defdbmode.Contains("SQL Server", StringComparison.OrdinalIgnoreCase)) {
            options.UseSqlServer(dbconstrsqlsrv);
        } else if (defdbmode.Contains("MySQL", StringComparison.OrdinalIgnoreCase)) {
            options.UseMySql(dbconstrmysql, ServerVersion.AutoDetect(dbconstrmysql));
        } else if (defdbmode.Contains("SQLite", StringComparison.OrdinalIgnoreCase)) {
            options.UseSqlite(dbconstrsqllite);
        } else {
            options.UseSqlServer(dbconstrsqlsrv);
        }
    }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        base.OnModelCreating(mb);
        new DBOpData(mb).SetupForeignKeys(false);
        new DBOpData(mb).Seed(false);
    }
}