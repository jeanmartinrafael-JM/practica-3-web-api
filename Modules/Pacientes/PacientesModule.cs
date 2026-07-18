using ReservaCitasMedicasJ.Modules.Pacientes.Repositories;
using ReservaCitasMedicasJ.Modules.Pacientes.Services;

namespace ReservaCitasMedicasJ.Modules.Pacientes;

public static class PacientesModule
{
    public static IServiceCollection AddPacientesModule(this IServiceCollection services)
    {
        services.AddScoped<PacientesService>();
        services.AddScoped<PacientesRepository>();
        return services;
    }
}