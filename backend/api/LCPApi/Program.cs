using System.Text;
using LCPApi.Context;
using LCPApi.Interfaces;
using LCPApi.Models;
using LCPApi.Repositories;
using LCPApi.Functions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DBContext>(optionsBuilder => optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("LCPDBSqlServer")));
builder.Services.AddControllers();

builder.Services.AddScoped<ICustomers, RCustomers>();
builder.Services.AddScoped<ICategories, RCategories>();
builder.Services.AddScoped<IDepartments, RDepartments>();
builder.Services.AddScoped<IEmployees, REmployees>();
builder.Services.AddScoped<IFeedbacks, RFeedbacks>();
builder.Services.AddScoped<IFeedbacksComments, RFeedbacksComments>();
builder.Services.AddScoped<IOrders, ROrders>();
builder.Services.AddScoped<IOrdersCustomers, ROrdersCustomers>();
builder.Services.AddScoped<IProducts, RProducts>();
builder.Services.AddScoped<IProductsProjects, RProductsProjects>();
builder.Services.AddScoped<IProductsSubscriptions, RProductsSubscriptions>();
builder.Services.AddScoped<IProjects, RProjects>();
builder.Services.AddScoped<IProjectsPhases, RProjectsPhases>();
builder.Services.AddScoped<ISubscriptions, RSubscriptions>();
builder.Services.AddScoped<ISubscriptionsKeys, RSubscriptionsKeys>();
builder.Services.AddScoped<ITasks, RTasks>();
builder.Services.AddScoped<ITasksTypes, RTasksTypes>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddAuthorization();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { 
        Version = "v1",
        Title = "LCPApi", 
        Description = "LCP Api",
        TermsOfService = new Uri("https://lcp-pi.vercel.app/pt"),
        Contact = new OpenApiContact {
            Name = "Luis Carvalho Projects",
            Email = "luiscarvalho239@gmail.com",
            Url = new Uri("https://lcp-pi.vercel.app/pt")
        },
        License = new OpenApiLicense {
            Name = "Apache 2.0",
            Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
        }
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Scheme = "bearer",
        Description = "Please insert JWT token into field"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.MapPost("/security/createToken", [AllowAnonymous] (Employees employee) => AuthFunctions.GenToken(builder, employee));

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
