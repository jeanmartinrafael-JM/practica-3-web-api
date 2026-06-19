using ReservaCitasMedicasJ.Modules.Citas.Repositories;
using ReservaCitasMedicasJ.Modules.Citas.Services;

namespace ReservaCitasMedicasJ.Modules.Citas;

public static class CitasModule
{
    public static IServiceCollection AddCitasModule(this IServiceCollection services)
    {
        services.AddScoped<CitasService>();
        services.AddScoped<CitasRepository>();
        return services;
    }
}