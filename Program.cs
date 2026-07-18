using Microsoft.EntityFrameworkCore;
using ReservaCitasMedicasJ.Data;
using ReservaCitasMedicasJ.Modules.Citas;
using ReservaCitasMedicasJ.Modules.Pacientes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddCitasModule();
builder.Services.AddPacientesModule();
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment()) app.MapOpenApi();

app.UseHttpsRedirection();
app.MapControllers();

app.Run("http://localhost:3000");