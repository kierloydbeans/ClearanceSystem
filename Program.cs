using CMS.Application.Features.Authentication.Login;
using CMS.Application.Features.Authentication.Registration;
using CMS.Infrastructure.Authentication;
using CMS.Infrastructure.Data;
using CMS.Infrastructure.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IRegisterService, RegisterService>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])),
            ValidateIssuer = false, 
            ValidateAudience = false 
        };
    });

var applicationAssembly = typeof(CMS.Application.Features.Authentication.Registration.RegisterUserCommand).Assembly;
builder.Services.AddValidatorsFromAssembly(applicationAssembly);



var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.MapFallbackToFile("index.html");

app.MapControllers();

app.Run();
