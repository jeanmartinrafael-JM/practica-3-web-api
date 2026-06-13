namespace ReservaCitasMedicasJ.Modules.Citas.Dtos
{
    public class CrearCitaDto
    {
        public string Paciente { get; set; } = string.Empty;
        public string Doctor { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; } = string.Empty;
    }
}