using FilterExample1.MIddleware;
using FilterExample1.Services;
using FilterExample1.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<TransactionLogService>(); //custom

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

void ConfigureServices(IServiceCollection services) 
{
    services.AddControllers(i => i.Filters.Add<ValidationFilterAttribute>());
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<RoleMiddleware>();  //custom

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
