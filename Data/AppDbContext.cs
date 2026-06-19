using Microsoft.EntityFrameworkCore;
using ReservaCitasMedicasJ.Modules.Citas.Entities;

namespace ReservaCitasMedicasJ.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Cita> Citas => Set<Cita>();
}