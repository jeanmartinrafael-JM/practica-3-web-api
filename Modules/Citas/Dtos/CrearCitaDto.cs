
namespace ReservaCitasMedicasJ.Modules.Citas.Dtos;

public class CrearCitaDto
{
    public required string Doctor { get; set; }
    public DateTime Fecha { get; set; }
    public required string Motivo { get; set; }
    public int PacienteId { get; set; }
}