#!/usr/bin/sh

# src: https://learn.microsoft.com/pt-br/aspnet/core/tutorials/first-web-api?view=aspnetcore-7.0&tabs=visual-studio-code#scaffold-a-controller

cd ".."
rm -rf Controllers
mkdir -p Controllers

dotnet aspnet-codegenerator controller -name CustomersController -async -api -m Customers -dc DBContext -outDir Controllers
dotnet aspnet-codegenerator controller -name EmployeesController -async -api -m Employees -dc DBContext -outDir Controllers
dotnet aspnet-codegenerator controller -name ProductsController -async -api -m Products -dc DBContext -outDir Controllers
dotnet aspnet-codegenerator controller -name OrdersController -async -api -m Orders -dc DBContext -outDir Controllers
dotnet aspnet-codegenerator controller -name SubscriptionsController -async -api -m Subscriptions -dc DBContext -outDir Controllers
dotnet aspnet-codegenerator controller -name ProjectsController -async -api -m Projects -dc DBContext -outDir Controllers
dotnet aspnet-codegenerator controller -name CategoriesController -async -api -m Categories -dc DBContext -outDir Controllers
dotnet aspnet-codegenerator controller -name FeedbacksController -async -api -m Feedbacks -dc DBContext -outDir Controllers
dotnet aspnet-codegenerator controller -name DepartmentsController -async -api -m Departments -dc DBContext -outDir Controllers

exit