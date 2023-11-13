using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LCPApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriesDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoriesId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomersName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomersPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomersRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomersEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomersPin = table.Column<int>(type: "int", nullable: true),
                    CustomersFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomersLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomersJob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomersDateBirthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomersDateRegistered = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomersCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomersPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomersPostalAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomersCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomersZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomersStateProvince = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomersId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentsType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentsDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectsId = table.Column<int>(type: "int", nullable: true),
                    EmployeesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentsId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeesName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeesPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeesRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeesEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeesPin = table.Column<int>(type: "int", nullable: true),
                    EmployeesFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeesLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeesJob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeesDateBirthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeesDateRegistered = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeesCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeesPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeesPostalAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeesCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeesZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeesStateProvince = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeesId);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    FeedbacksId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedbacksTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeedbacksMsg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedbacksStatus = table.Column<int>(type: "int", nullable: true),
                    FeedbacksDateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FeedbacksDateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FeedbacksDateLocked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FeedbacksAssignBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedbacksUpvotes = table.Column<int>(type: "int", nullable: true),
                    FeedbacksDownvotes = table.Column<int>(type: "int", nullable: true),
                    CustomersId = table.Column<int>(type: "int", nullable: true),
                    ProjectsId = table.Column<int>(type: "int", nullable: true),
                    CommentsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.FeedbacksId);
                });

            migrationBuilder.CreateTable(
                name: "FeedbacksComments",
                columns: table => new
                {
                    FeedbacksCommentsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedbacksCommentsMsg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeedbacksCommentsUpvotes = table.Column<int>(type: "int", nullable: true),
                    FeedbacksCommentsDownvotes = table.Column<int>(type: "int", nullable: true),
                    FeedbacksCommentsStatus = table.Column<int>(type: "int", nullable: true),
                    FeedbacksCommentsDateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FeedbacksCommentsDateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FeedbacksCommentsDateLocked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FeedbacksId = table.Column<int>(type: "int", nullable: true),
                    CustomersId = table.Column<int>(type: "int", nullable: true),
                    ProjectsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbacksComments", x => x.FeedbacksCommentsId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ItemPrice = table.Column<double>(type: "float", nullable: false),
                    ItemDiscount = table.Column<double>(type: "float", nullable: false),
                    ItemStock = table.Column<double>(type: "float", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrdersId);
                });

            migrationBuilder.CreateTable(
                name: "OrdersCustomers",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomersId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersCustomers", x => x.OrdersId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductsTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductsType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductsDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductsPrice = table.Column<double>(type: "float", nullable: true),
                    ProductsImageMain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductsGallery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductsIsFeatured = table.Column<bool>(type: "bit", nullable: true),
                    ProductsDateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductsDateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomersId = table.Column<int>(type: "int", nullable: true),
                    EmployeesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductsId);
                });

            migrationBuilder.CreateTable(
                name: "ProductsProjects",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsProjects", x => x.ProductsId);
                });

            migrationBuilder.CreateTable(
                name: "ProductsSubscriptions",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsSubscriptions", x => x.ProductsId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectsDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectsCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectsOwner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectsCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectsPriority = table.Column<bool>(type: "bit", nullable: true),
                    ProjectsStatus = table.Column<int>(type: "int", nullable: true),
                    ProjectsDateStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectsDateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectsDateClose = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectsBudgetDays = table.Column<int>(type: "int", nullable: true),
                    ProjectsBudgetCost = table.Column<double>(type: "float", nullable: true),
                    ProjectsRecords = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectsId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectsPhases",
                columns: table => new
                {
                    ProjectsPhasesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectsPhasesName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectsPhasesDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectsPhasesStatus = table.Column<int>(type: "int", nullable: true),
                    ProjectsPhasesDateStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectsPhasesDateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectsPhasesActivities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TasksId = table.Column<int>(type: "int", nullable: true),
                    CategoriesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsPhases", x => x.ProjectsPhasesId);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    SubscriptionsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionsTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubscriptionsDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubscriptionsType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubscriptionsImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubscriptionsDatePurchased = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SubscriptionsDateEnded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SubscriptionsIsExpired = table.Column<bool>(type: "bit", nullable: true),
                    CustomersId = table.Column<int>(type: "int", nullable: true),
                    EmployeesId = table.Column<int>(type: "int", nullable: true),
                    ProductsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.SubscriptionsId);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionsKeys",
                columns: table => new
                {
                    SubscriptionsKeysId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionsKeysValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubscriptionsKeysDateStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SubscriptionsKeysDateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SubscriptionsKeysDateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SubscriptionsKeysStatus = table.Column<int>(type: "int", nullable: true),
                    SubscriptionsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionsKeys", x => x.SubscriptionsKeysId);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TasksId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TasksName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TasksDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TasksProject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TasksPhaseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TasksStatus = table.Column<int>(type: "int", nullable: false),
                    TasksOwner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TasksType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TasksPriority = table.Column<int>(type: "int", nullable: true),
                    TasksStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TasksEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TasksTeam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TasksReviewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TasksReviewReport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TasksDocument = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TasksDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectsId = table.Column<int>(type: "int", nullable: true),
                    CategoriesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TasksId);
                });

            migrationBuilder.CreateTable(
                name: "TasksTypes",
                columns: table => new
                {
                    TasksTypesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TasksTypesDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TasksId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasksTypes", x => x.TasksTypesId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "FeedbacksComments");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "OrdersCustomers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductsProjects");

            migrationBuilder.DropTable(
                name: "ProductsSubscriptions");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "ProjectsPhases");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "SubscriptionsKeys");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "TasksTypes");
        }
    }
}
