using LCPApi.Enums;
using LCPApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BC = BCrypt.Net.BCrypt;

namespace LCPApi.Context;

public class DBOpData 
{
    private readonly ModelBuilder _mb;
    public DBOpData(ModelBuilder mb)
    {
        _mb = mb;
    }

    public void SetupForeignKeys(Boolean isSetupFK) 
    {
        if(isSetupFK) {
            _mb.Entity<Product>().HasOne<Customer>(s => s.Customers).WithMany(g => g.Products).HasForeignKey(s => s.CustomerId);
            _mb.Entity<Product>().HasOne<Employee>(s => s.Employees).WithMany(g => g.Products).HasForeignKey(s => s.EmployeeId);
        }
    }

    public void Seed(Boolean isSeedData) 
    {
        if(isSeedData) {
            int seedval = 1000;

            List<Employee> listEmp = [
                new Employee { EmployeeId = 1001, EmployeeFirstName = "Luis", EmployeeLastName = "Carvalho", EmployeeCity = "Braga", EmployeeCountry = "Portugal", EmployeeStateProvince = "", EmployeeName = "admin", EmployeeEmail = "luiscarvalho239@gmail.com", EmployeeDateBirthday = DateTime.Parse("1996-06-04T00:00:00"), EmployeeDateRegistered = DateTime.Now, EmployeePassword = BC.HashPassword("Kw@?7t3z704M6-6B92XG"), EmployeePin = BC.HashPassword("1234"), EmployeeJob = "Programmer", EmployeePhoneNumber = "0123456789", EmployeePostalAddress = "1234-567", EmployeeZipCode = "1234-567", EmployeeRole = ENRoles.Administrator.ToString(), Products = null }
            ];

            _mb.Entity<Employee>(b => {
                b.ToTable("Employees");
                b.Property(x => x.EmployeeId).ValueGeneratedOnAdd().UseIdentityColumn(seedval, 1);
                b.HasData(listEmp);
            });
        }

        _mb.Entity<IdentityUser>().ToTable("AspNetUsers", t => t.ExcludeFromMigrations());
    }
}