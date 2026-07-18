using ReservaCitasMedicasJ.Data;
using ReservaCitasMedicasJ.Modules.Pacientes.Entities;

namespace ReservaCitasMedicasJ.Modules.Pacientes.Repositories;

public class PacientesRepository(AppDbContext appDbContext)
{
    private readonly AppDbContext _context = appDbContext;

    public List<Paciente> FindAll()
    {
        return _context.Pacientes.ToList();
    }

    public Paciente? FindOne(int id)
    {
        return _context.Pacientes.FirstOrDefault(p => p.Id == id);
    }

    public Paciente Create(Paciente paciente)
    {
        _context.Pacientes.Add(paciente);
        _context.SaveChanges();
        return paciente;
    }

    public Paciente Update(Paciente paciente)
    {
        _context.Update(paciente);
        _context.SaveChanges();
        return paciente;
    }

    public bool Delete(int id)
    {
        Paciente? paciente = FindOne(id);
        if (paciente is null) return false;
        _context.Pacientes.Remove(paciente);
        _context.SaveChanges();
        return true;
    }
}