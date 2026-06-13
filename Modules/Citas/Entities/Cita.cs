namespace ReservaCitasMedicasJ.Modules.Citas.Entities
{
    public class Cita
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Paciente { get; set; } = string.Empty;
        public string Doctor { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; } = string.Empty;
        public string Estado { get; set; } = "pendiente";
    }
}