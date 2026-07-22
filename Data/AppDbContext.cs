using Microsoft.EntityFrameworkCore;
using ReservaCitasMedicasJ.Modules.Citas.Entities;
using ReservaCitasMedicasJ.Modules.Pacientes.Entities;

namespace ReservaCitasMedicasJ.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Cita> Citas => Set<Cita>();
    public DbSet<Paciente> Pacientes => Set<Paciente>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Uuid autogenerado para Cita
        modelBuilder.Entity<Cita>()
            .Property(x => x.Uuid)
            .HasDefaultValueSql("gen_random_uuid()");

        // Uuid autogenerado para Paciente
        modelBuilder.Entity<Paciente>()
            .Property(x => x.Uuid)
            .HasDefaultValueSql("gen_random_uuid()");

        // Relacion Uno a Muchos: Paciente tiene muchas Citas
        modelBuilder.Entity<Cita>()
            .HasOne(x => x.Paciente)
            .WithMany(x => x.Citas)
            .HasForeignKey(x => x.PacienteId);
    }
}