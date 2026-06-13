using ReservaCitasMedicasJ.Modules.Citas.Entities;
using ReservaCitasMedicasJ.Modules.Citas.Dtos;

namespace ReservaCitasMedicasJ.Modules.Citas.Services
{
    public class CitasService
    {
        private readonly List<Cita> _citas = new();

        public List<Cita> ObtenerTodos()
        {
            return _citas;
        }

        public Cita? ObtenerPorId(Guid id)
        {
            return _citas.FirstOrDefault(c => c.Id == id);
        }

        public Cita Crear(CrearCitaDto dto)
        {
            var cita = new Cita
            {
                Paciente = dto.Paciente,
                Doctor = dto.Doctor,
                Fecha = dto.Fecha,
                Motivo = dto.Motivo
            };
            _citas.Add(cita);
            return cita;
        }

        public Cita? Actualizar(Guid id, ActualizarCitaDto dto)
        {
            var cita = _citas.FirstOrDefault(c => c.Id == id);
            if (cita is null) return null;

            if (dto.Paciente is not null) cita.Paciente = dto.Paciente;
            if (dto.Doctor is not null) cita.Doctor = dto.Doctor;
            if (dto.Fecha is not null) cita.Fecha = dto.Fecha.Value;
            if (dto.Motivo is not null) cita.Motivo = dto.Motivo;
            if (dto.Estado is not null) cita.Estado = dto.Estado;

            return cita;
        }

        public bool Eliminar(Guid id)
        {
            var cita = _citas.FirstOrDefault(c => c.Id == id);
            if (cita is null) return false;
            _citas.Remove(cita);
            return true;
        }
    }
}