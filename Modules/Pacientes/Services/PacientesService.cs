using ReservaCitasMedicasJ.Modules.Pacientes.Dtos;
using ReservaCitasMedicasJ.Modules.Pacientes.Entities;
using ReservaCitasMedicasJ.Modules.Pacientes.Repositories;

namespace ReservaCitasMedicasJ.Modules.Pacientes.Services;

public class PacientesService(PacientesRepository pacientesRepository)
{
    private readonly PacientesRepository _repository = pacientesRepository;

    public List<Paciente> FindAll()
    {
        return _repository.FindAll();
    }

    public Paciente? FindOne(int id)
    {
        return _repository.FindOne(id);
    }

    public Paciente Create(CrearPacienteDto dto)
    {
        Paciente paciente = new()
        {
            Nombre = dto.Nombre,
            Telefono = dto.Telefono,
            Email = dto.Email,
            FechaNacimiento = dto.FechaNacimiento,
            Direccion = dto.Direccion
        };
        return _repository.Create(paciente);
    }

    public Paciente? Update(int id, ActualizarPacienteDto dto)
    {
        Paciente? paciente = FindOne(id);
        if (paciente is null) return null;

        if (dto.Nombre is not null) paciente.Nombre = dto.Nombre;
        if (dto.Telefono is not null) paciente.Telefono = dto.Telefono;
        if (dto.Email is not null) paciente.Email = dto.Email;
        if (dto.FechaNacimiento is not null) paciente.FechaNacimiento = dto.FechaNacimiento.Value;
        if (dto.Direccion is not null) paciente.Direccion = dto.Direccion;

        return _repository.Update(paciente);
    }

    public bool Delete(int id)
    {
        return _repository.Delete(id);
    }
}