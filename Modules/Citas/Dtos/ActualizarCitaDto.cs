namespace ReservaCitasMedicasJ.Modules.Citas.Dtos;

public class ActualizarCitaDto
{
    public string? Doctor { get; set; }
    public DateTime? Fecha { get; set; }
    public string? Motivo { get; set; }
    public string? Estado { get; set; }
    public int? PacienteId { get; set; }
}