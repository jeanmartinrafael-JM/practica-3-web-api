using Microsoft.AspNetCore.Mvc;
using ReservaCitasMedicasJ.Modules.Citas.Dtos;
using ReservaCitasMedicasJ.Modules.Citas.Entities;
using ReservaCitasMedicasJ.Modules.Citas.Services;

namespace ReservaCitasMedicasJ.Modules.Citas.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class CitasController(CitasService citasService) : ControllerBase
{
    private readonly CitasService _service = citasService;

    [HttpGet]
    public IActionResult FindAll()
    {
        return Ok(_service.FindAll());
    }

    [HttpGet("{id}")]
    public IActionResult FindOne(int id)
    {
        Cita? cita = _service.FindOne(id);
        if (cita is null)
            return NotFound(new { Message = "Cita no encontrada." });
        return Ok(cita);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CrearCitaDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Paciente) ||
            string.IsNullOrWhiteSpace(dto.Doctor) ||
            string.IsNullOrWhiteSpace(dto.Motivo))
            return BadRequest(new { Message = "Los campos Paciente, Doctor y Motivo son obligatorios." });

        return Ok(_service.Create(dto));
    }

    [HttpPatch("{id}")]
    public IActionResult Update(int id, [FromBody] ActualizarCitaDto dto)
    {
        if (dto.Paciente is null && dto.Doctor is null &&
            dto.Fecha is null && dto.Motivo is null && dto.Estado is null)
            return BadRequest(new { Message = "Debe enviar al menos un campo para actualizar." });

        Cita? cita = _service.Update(id, dto);
        if (cita is null)
            return NotFound(new { Message = "Cita no encontrada." });
        return Ok(new { Message = "Cita actualizada correctamente." });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        bool eliminado = _service.Delete(id);
        if (!eliminado)
            return NotFound(new { Message = "Cita no encontrada." });
        return NoContent();
    }
}