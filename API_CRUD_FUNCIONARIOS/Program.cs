using API_CRUD_FUNCIONARIOS.Context;
using API_CRUD_FUNCIONARIOS.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IFuncionarioService, FuncionarioService>();



builder.Services.AddControllers();

//db
var serverVersion = new MySqlServerVersion(new Version(8, 0, 41));
builder.Services.AddDbContext<FuncionarioContext>(options =>
 options.UseMySql(builder.Configuration.GetConnectionString("Default"), serverVersion)
 
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
