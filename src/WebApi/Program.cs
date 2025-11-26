using Infrastructure.Data;
using Infrastructure.Logging;

var builder = WebApplication.CreateBuilder(args);

// habilitar controllers
builder.Services.AddControllers();

// configurar CORS (ejemplo inseguro, solo para pruebas)
builder.Services.AddCors(o => o.AddPolicy("bad", p =>
    p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

// configurar middlewares
app.UseCors("bad");
app.UseRouting();
app.UseAuthorization();

// mapear controllers
app.MapControllers();

app.Run();