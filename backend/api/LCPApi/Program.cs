using System.Text;
using System.Text.Json.Serialization;
using LCPApi.Context;
using LCPApi.Interfaces;
using LCPApi.Repositories;
using LCPApi.Enums;
using LCPApi.Hubs;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var logger =  new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddDbContext<DBContext>();
builder.Services.AddCors();
builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

builder.Services.AddScoped<ICustomer, RCustomer>();
builder.Services.AddScoped<ICategory, RCategory>();
builder.Services.AddScoped<IDepartment, RDepartment>();
builder.Services.AddScoped<IEmployee, REmployee>();
builder.Services.AddScoped<IFeedback, RFeedback>();
builder.Services.AddScoped<IOrder, ROrder>();
builder.Services.AddScoped<IProduct, RProduct>();
builder.Services.AddScoped<IProject, RProject>();
builder.Services.AddScoped<ISubscription, RSubscription>();

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
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        RequireExpirationTime = true,
        ClockSkew = TimeSpan.Zero,
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("GuestsOnly", policy => policy.RequireRole(ENRoles.Guest.ToString()));
    options.AddPolicy("UsersOnly", policy => policy.RequireRole(ENRoles.User.ToString()));
    options.AddPolicy("CustomersOnly", policy => policy.RequireRole(ENRoles.Customer.ToString()));
    options.AddPolicy("EmployeesOnly", policy => policy.RequireRole(ENRoles.Employee.ToString()));
    options.AddPolicy("EditorsOnly", policy => policy.RequireRole(ENRoles.Editor.ToString()));
    options.AddPolicy("ModeratorsOnly", policy => policy.RequireRole(ENRoles.Moderator.ToString()));
    options.AddPolicy("AdminsOnly", policy => policy.RequireRole(ENRoles.Administrator.ToString()));
    options.AddPolicy("StaffOnly", policy => policy.RequireRole(ENRoles.Administrator.ToString(), ENRoles.Moderator.ToString()));
    options.AddPolicy("AllRights", policy => policy.RequireRole(ENRoles.Guest.ToString(), ENRoles.User.ToString(), ENRoles.Customer.ToString(), ENRoles.Employee.ToString(), ENRoles.Editor.ToString(), ENRoles.Moderator.ToString(), ENRoles.Administrator.ToString()));
});

builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.SwaggerDoc("v1", new OpenApiInfo { 
        Version = "v1",
        Title = "LCPApi", 
        Description = "LCP (Luis Carvalho Projects) Api",
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
builder.Services.AddSignalR();

var app = builder.Build();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        c.EnablePersistAuthorization();
    });
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHub<DataHub>("/dataHub");

app.Run();
