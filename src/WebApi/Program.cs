using Infrastructure.Data;
using Infrastructure.Logging;

var builder = WebApplication.CreateBuilder(args);

// habilitar controllers
builder.Services.AddControllers();

builder.Services.AddCors(o => o.AddPolicy("bad", p =>
    p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();
app.UseCors("bad");
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();