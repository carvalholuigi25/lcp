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
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerPin = table.Column<int>(type: "int", nullable: true),
                    CustomerFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerJob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerDateBirthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerDateRegistered = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerPostalAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerStateProvince = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeePassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeePin = table.Column<int>(type: "int", nullable: true),
                    EmployeeFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeJob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeDateBirthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeDateRegistered = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeePhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeePostalAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeStateProvince = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedbackTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeedbackMsg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedbackStatus = table.Column<int>(type: "int", nullable: true),
                    FeedbackDateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FeedbackDateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FeedbackDateLocked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FeedbackAssignBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedbackUpvotes = table.Column<int>(type: "int", nullable: true),
                    FeedbackDownvotes = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    CommentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.FeedbackId);
                });

            migrationBuilder.CreateTable(
                name: "FeedbacksComments",
                columns: table => new
                {
                    FeedbackCommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedbackCommentMsg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeedbackCommentUpvotes = table.Column<int>(type: "int", nullable: true),
                    FeedbackCommentDownvotes = table.Column<int>(type: "int", nullable: true),
                    FeedbackCommentStatus = table.Column<int>(type: "int", nullable: true),
                    FeedbackCommentDateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FeedbackCommentDateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FeedbackCommentDateLocked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FeedbackId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbacksComments", x => x.FeedbackCommentId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ItemPrice = table.Column<double>(type: "float", nullable: false),
                    ItemDiscount = table.Column<double>(type: "float", nullable: false),
                    ItemStock = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "OrdersCustomers",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersCustomers", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "ProductsProjects",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsProjects", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "ProductsSubscriptions",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsSubscriptions", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectOwner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectPriority = table.Column<bool>(type: "bit", nullable: true),
                    ProjectStatus = table.Column<int>(type: "int", nullable: true),
                    ProjectDateStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectDateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectDateClose = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectBudgetDays = table.Column<int>(type: "int", nullable: true),
                    ProjectBudgetCost = table.Column<double>(type: "float", nullable: true),
                    ProjectRecords = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectsPhases",
                columns: table => new
                {
                    ProjectPhaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectPhaseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectPhaseDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectPhaseStatus = table.Column<int>(type: "int", nullable: true),
                    ProjectPhaseDateStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectPhaseDateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectPhaseActivities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsPhases", x => x.ProjectPhaseId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTasks",
                columns: table => new
                {
                    ProjectTaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectTaskName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectTaskDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectTaskProject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectTaskPhaseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectTaskStatus = table.Column<int>(type: "int", nullable: false),
                    ProjectTaskOwner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectTaskType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectTaskPriority = table.Column<int>(type: "int", nullable: true),
                    ProjectTaskStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectTaskEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectTaskTeam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectTaskReviewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectTaskReviewReport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectTaskDocument = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectTaskDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTasks", x => x.ProjectTaskId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTasksTypes",
                columns: table => new
                {
                    ProjectTaskTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectTaskTypeDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectTaskId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTasksTypes", x => x.ProjectTaskTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    SubscriptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubscriptionDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubscriptionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubscriptionImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubscriptionDatePurchased = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SubscriptionDateEnded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SubscriptionIsExpired = table.Column<bool>(type: "bit", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.SubscriptionId);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionsKeys",
                columns: table => new
                {
                    SubscriptionKeyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionKeyValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubscriptionKeyDateStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SubscriptionKeyDateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SubscriptionKeyDateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SubscriptionKeyStatus = table.Column<int>(type: "int", nullable: true),
                    SubscriptionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionsKeys", x => x.SubscriptionKeyId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductPrice = table.Column<double>(type: "float", nullable: true),
                    ProductImageMain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductGallery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductIsFeatured = table.Column<bool>(type: "bit", nullable: true),
                    ProductDateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductDateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_Products_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CustomerId",
                table: "Products",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_EmployeeId",
                table: "Products",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Departments");

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
                name: "ProjectTasks");

            migrationBuilder.DropTable(
                name: "ProjectTasksTypes");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "SubscriptionsKeys");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
