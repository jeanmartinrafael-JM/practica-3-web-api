using Microsoft.EntityFrameworkCore;
using ReservaCitasMedicasJ.Data;
using ReservaCitasMedicasJ.Modules.Citas.Entities;

namespace ReservaCitasMedicasJ.Modules.Citas.Repositories;

public class CitasRepository(AppDbContext appDbContext)
{
    private readonly AppDbContext _context = appDbContext;

    public List<Cita> FindAll()
    {
        return _context.Citas
            .Include(c => c.Paciente)
            .ToList();
    }

    public Cita? FindOne(int id)
    {
        return _context.Citas
            .Include(c => c.Paciente)
            .FirstOrDefault(c => c.Id == id);
    }

    public Cita Create(Cita cita)
    {
      _context.Citas.Add(cita);
      _context.SaveChanges();
      _context.Entry(cita).Reference(c => c.Paciente).Load();
      return cita;
    }

    public Cita Update(Cita cita)
    {
        _context.Update(cita);
        _context.SaveChanges();
        return cita;
    }

    public bool Delete(int id)
    {
        Cita? cita = FindOne(id);
        if (cita is null) return false;
        _context.Citas.Remove(cita);
        _context.SaveChanges();
        return true;
    }
}