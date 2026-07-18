namespace ReservaCitasMedicasJ.Modules.Pacientes.Entities;

public class Paciente
{
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public required string Telefono { get; set; }
    public required string Email { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public required string Direccion { get; set; }
}