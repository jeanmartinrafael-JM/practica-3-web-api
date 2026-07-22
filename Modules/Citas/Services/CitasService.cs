using ReservaCitasMedicasJ.Modules.Citas.Dtos;
using ReservaCitasMedicasJ.Modules.Citas.Entities;
using ReservaCitasMedicasJ.Modules.Citas.Repositories;

namespace ReservaCitasMedicasJ.Modules.Citas.Services;

public class CitasService(CitasRepository citasRepository)
{
    private readonly CitasRepository _repository = citasRepository;

    public List<Cita> FindAll()
    {
        return _repository.FindAll();
    }

    public Cita? FindOne(int id)
    {
        return _repository.FindOne(id);
    }

    public Cita Create(CrearCitaDto dto)
    {
        Cita cita = new()
        {
            Doctor = dto.Doctor,
            Fecha = dto.Fecha,
            Motivo = dto.Motivo,
            PacienteId = dto.PacienteId
        };
        return _repository.Create(cita);
    }

    public Cita? Update(int id, ActualizarCitaDto dto)
    {
        Cita? cita = FindOne(id);
        if (cita is null) return null;

        if (dto.Doctor is not null) cita.Doctor = dto.Doctor;
        if (dto.Fecha is not null) cita.Fecha = dto.Fecha.Value;
        if (dto.Motivo is not null) cita.Motivo = dto.Motivo;
        if (dto.Estado is not null) cita.Estado = dto.Estado;
        if (dto.PacienteId is not null) cita.PacienteId = dto.PacienteId.Value;

        return _repository.Update(cita);
    }

    public bool Delete(int id)
    {
        return _repository.Delete(id);
    }
}