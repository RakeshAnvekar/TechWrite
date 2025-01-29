using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using TechWriteServer.Autentication;
using TechWriteServer.BusinessLogics;
using TechWriteServer.BusinessLogics.Interfaces;
using TechWriteServer.DbContext;
using TechWriteServer.Enums;
using TechWriteServer.Helpers;
using TechWriteServer.Helpers.Interfaces;
using TechWriteServer.MiddleWares;
using TechWriteServer.Models.User;
using TechWriteServer.Repositories;
using TechWriteServer.Repositories.Interfaces;
using TechWriteServer.Validators.FluentApiModelValidators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminRole", policy => policy.RequireRole(UserTypes.Admin.ToString())); // Admin role
    options.AddPolicy("UserRole", policy => policy.RequireRole(UserTypes.User.ToString()));   // User role
    options.AddPolicy("VisitorRole", policy => policy.RequireRole(UserTypes.Visitor.ToString())); // Visitor role
});
#region Configure JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                     options.Events = new JwtBearerEvents
                    {
                         //This event is fired every time a request is received by the server
                         OnMessageReceived = context =>
                        {
                            // Get the JWT token from the cookie
                            var token = context.HttpContext.Request.Cookies["AuthToken"];
                            if (!string.IsNullOrEmpty(token))
                            {
                                context.Token = token;
                            }
                            return Task.CompletedTask;
                        }

                         
                     };
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"])),
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"]
                    };
                });
#endregion

#region Fluent API Registration
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddTransient<IValidator<User>, UserValidator>();
#endregion

#region Entity Framewrork DbContext

builder.Services.AddDbContext<TechWriteAppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
});

#endregion

#region Helpers
builder.Services.AddSingleton<IPasswordHasherHelper, PasswordHasherHelper>();
builder.Services.AddSingleton<IDateTimeConverterHelper, DateTimeConverterHelper>();
builder.Services.AddSingleton<ICookieHelper, CookieHelper>();
#endregion

#region Business Logic
builder.Services.AddTransient<IBlogLogic, BlogLogic>();
builder.Services.AddTransient<ITagLogic, TagLogic>();
builder.Services.AddTransient<IUserLogic, UserLogic>();
builder.Services.AddTransient<IBlogLikeLogic, BlogLikeLogic>();
#endregion

#region Repositories

builder.Services.AddScoped<IUserTypeRepository, UserTypeRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBlogCommentRepository, BlogCommentRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<IBlogLikeRepository, BlogLikeRepository>();

#endregion

#region Custom Auth
builder.Services.AddScoped<ITokenGenerator, TokenGenerator>();
#endregion
var app = builder.Build();

builder.Services.AddAuthorization();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
var allowedMethods = new[] { "GET", "POST", "PUT", "DELETE" };
#region MiddleWares
app.Use(async (context,next) =>
{
    var middleWare= new MethodAllowedMiddleWare(next,allowedMethods);
   await middleWare.InvokeAsyc(context);
});
app.UseMiddleware<HealthCheckMiddleWare>();
#endregion
app.UseStatusCodePagesWithReExecute("/Error/HandleError", "?statusCode={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Blog}/{action=Index}/{id?}");

app.Run();
