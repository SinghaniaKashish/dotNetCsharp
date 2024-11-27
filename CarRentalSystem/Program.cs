using CarRentalSystem.Data;
using CarRentalSystem.Middleware;
using CarRentalSystem.Services;
using CarRentalSystem.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var jwtval = builder.Configuration.GetSection("Jwt");  //c
var key = Encoding.UTF8.GetBytes(jwtval["Key"]);  //c

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//connect to db
builder.Services.AddDbContext<CarRentalDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//auth
builder.Services.AddAuthentication(i => {
    i.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    i.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(i =>
{
    i.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtval["Issuer"],
        ValidAudience = jwtval["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder.Services.AddAuthorization(i =>
{
    i.AddPolicy("AdminOnly", j => j.RequireRole("Admin"));
    i.AddPolicy("All", j => j.RequireRole("Admin", "User"));
});

//services repositories
builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped< ICarRepository, CarRepository>();
builder.Services.AddScoped< IUserRepository, UserRepository>();
builder.Services.AddScoped< IUserService, UserService>();
builder.Services.AddScoped< ICarService, CarService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<LoginMiddleware>();//c

app.UseHttpsRedirection();
app.UseAuthentication();//c
app.UseAuthorization();

app.MapControllers();

app.Run();
