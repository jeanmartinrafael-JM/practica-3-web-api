using ReservaCitasMedicasJ.Modules.Citas;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCitasModule();

var app = builder.Build();

app.MapControllers();

app.Run();