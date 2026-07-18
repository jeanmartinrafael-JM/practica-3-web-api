using Microsoft.EntityFrameworkCore;
using ReservaCitasMedicasJ.Modules.Citas.Entities;
using ReservaCitasMedicasJ.Modules.Pacientes.Entities;

namespace ReservaCitasMedicasJ.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Cita> Citas => Set<Cita>();
    public DbSet<Paciente> Pacientes => Set<Paciente>();  
}