namespace ReservaCitasMedicasJ.Modules.Citas.Entities;

public class Cita
{
    public int Id { get; set; }
    public required string Paciente { get; set; }
    public required string Doctor { get; set; }
    public DateTime Fecha { get; set; }
    public required string Motivo { get; set; }
    public string Estado { get; set; } = "pendiente";
}