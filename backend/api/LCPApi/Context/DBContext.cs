using Microsoft.EntityFrameworkCore;
using LCPApi.Models;

namespace LCPApi.Context;

public class DBContext : DbContext {
    public DbSet<Customers> Customers { get; set; }
    public DbSet<Employees> Employees { get; set; }
    public DbSet<Products> Products { get; set; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<OrdersCustomers> OrdersCustomers { get; set; }
    public DbSet<Subscriptions> Subscriptions { get; set; }
    public DbSet<ProductsSubscriptions> ProductsSubscriptions { get; set; }
    public DbSet<SubscriptionsKeys> SubscriptionsKeys { get; set; }
    public DbSet<Projects> Projects { get; set; }
    public DbSet<Categories> Categories { get; set; }
    public DbSet<Tasks> Tasks { get; set; }
    public DbSet<TasksTypes> TasksTypes { get; set; }
    public DbSet<ProjectsPhases> ProjectsPhases { get; set; }
    public DbSet<ProductsProjects> ProductsProjects { get; set; }
    public DbSet<Feedbacks> Feedbacks { get; set; }
    public DbSet<FeedbacksComments> FeedbacksComments { get; set; }
    public DbSet<Departments> Departments { get; set; }

    public DBContext(DbContextOptions<DBContext> options) : base(options)
    {
        
    }
}