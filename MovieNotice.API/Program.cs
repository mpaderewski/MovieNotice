using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MovieNotice.API.Data;
using MovieNotice.API.Entities;
using MovieNotice.API.Interfaces;
using MovieNotice.API.Services;
using MovieNotice.API.Services.Validators;
using MovieNotice.API.Settings;
using MovieNotice.Common.ModelsDto;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var authenitactionSettings = new AuthenitactionSettings();
var connectionSettings = new ConnectionStringsSettings();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

ConfigurationManager configuration = builder.Configuration;

configuration.GetSection("Authentication").Bind(authenitactionSettings);
configuration.GetSection("ConnectionStrings").Bind(connectionSettings);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                      });
});

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = "Bearer";
    option.DefaultScheme = "Bearer";
    option.DefaultChallengeScheme = "Bearer";
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata= false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidIssuer = authenitactionSettings.JwtIssuer,
        ValidAudience = authenitactionSettings.JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenitactionSettings.JwtKey))
    };
});

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IRemoteMovieApi, RemoteMovieApi>();
builder.Services.AddSingleton(authenitactionSettings);
builder.Services.AddSingleton(connectionSettings);
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IRemoteMoviesService, RemoteMoviesService>();
builder.Services.AddDbContext<MovieNoticeDbContext>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();
