namespace ReservaCitasMedicasJ.Modules.Pacientes.Dtos;

public class CrearPacienteDto
{
    public required string Nombre { get; set; }
    public required string Telefono { get; set; }
    public required string Email { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public required string Direccion { get; set; }
}