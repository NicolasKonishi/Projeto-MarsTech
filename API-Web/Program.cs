using API_Web.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<QuestionarioContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexaoPadrao")));

builder.Host.ConfigureAppConfiguration(config =>
{
    var settings = config.Build();
    config.AddAzureAppConfiguration("Endpoint=https://marstech-configuration.azconfig.io;Id=a9iU;Secret=EGdsfJ149KDAcsksQbTRMMQqtRcBUfPFhzxNzLLw0EnzQ3tSpb8cJQQJ99AIACZoyfiS85EQAAACAZACIRLd");
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
          builder =>
          {
              builder.AllowAnyOrigin()
                     .AllowAnyHeader()
                     .AllowAnyMethod();
          });
});


builder.Services.AddLogging();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
