using System.Text.Json.Serialization;
using ReservaCitasMedicasJ.Modules.Citas.Entities;

namespace ReservaCitasMedicasJ.Modules.Pacientes.Entities;

public class Paciente
{
    public int Id { get; set; }
    public Guid Uuid { get; set; }
    public required string Nombre { get; set; }
    public required string Telefono { get; set; }
    public required string Email { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public required string Direccion { get; set; }
    [JsonIgnore]
    public List<Cita> Citas { get; set; } = new();
}