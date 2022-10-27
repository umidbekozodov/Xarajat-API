using Microsoft.EntityFrameworkCore;
using Xarajat_API.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<XarajatDbContext>(option => 
{
    option.UseSqlite(builder.Configuration.GetConnectionString("DefaulTConnection"));
});
var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI();

app.MapControllers();

app.Run();
