using Microsoft.EntityFrameworkCore;
using SalesApp.Api.Data;
using SalesApp.Api.Interfaces;
using SalesApp.Api.Repositories;
using SalesApp.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add CORS policy
builder.Services.AddCors(options => options.AddPolicy(name: "AllowFrontend",
        policy => policy
            .WithOrigins("http://localhost:5174", "http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
    )
);

// Add services to the container.
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IDocumentTypeService, DocumentTypeService>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();
app.UseCors("AllowFrontend");

// Migrate database
using (var scope = app.Services.CreateScope())
{
    var database = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    database.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();