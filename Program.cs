var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();  // opcional

var app = builder.Build();

app.UseStaticFiles(); // permite servir HTML/JS/CSS de wwwroot

app.MapControllers();

app.Run();

