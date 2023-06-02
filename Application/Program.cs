using Infrastructure.DatabaseContext;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(
    "Data Source=PasswordVaultApp.db"
    )
);
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    var scope = app.Services.CreateScope();
    var dbService = scope.ServiceProvider.GetService<AppDbContext>();
    ArgumentNullException.ThrowIfNull(dbService, nameof(dbService));
    new DataSeeder(dbService).Run();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
