namespace ReservaCitasMedicasJ.Modules.Citas.Dtos
{
    public class ActualizarCitaDto
    {
        public string? Paciente { get; set; }
        public string? Doctor { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Motivo { get; set; }
        public string? Estado { get; set; }
    }
}