using Microsoft.AspNetCore.Mvc;
using ReservaCitasMedicasJ.Modules.Pacientes.Dtos;
using ReservaCitasMedicasJ.Modules.Pacientes.Entities;
using ReservaCitasMedicasJ.Modules.Pacientes.Services;

namespace ReservaCitasMedicasJ.Modules.Pacientes.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class PacientesController(PacientesService pacientesService) : ControllerBase
{
    private readonly PacientesService _service = pacientesService;

    [HttpGet]
    public IActionResult FindAll()
    {
        return Ok(_service.FindAll());
    }

    [HttpGet("{id}")]
    public IActionResult FindOne(int id)
    {
        Paciente? paciente = _service.FindOne(id);
        if (paciente is null)
            return NotFound(new { Message = "Paciente no encontrado." });
        return Ok(paciente);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CrearPacienteDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Nombre) ||
            string.IsNullOrWhiteSpace(dto.Telefono) ||
            string.IsNullOrWhiteSpace(dto.Email) ||
            string.IsNullOrWhiteSpace(dto.Direccion))
            return BadRequest(new { Message = "Todos los campos son obligatorios." });

        return Ok(_service.Create(dto));
    }

    [HttpPatch("{id}")]
    public IActionResult Update(int id, [FromBody] ActualizarPacienteDto dto)
    {
        if (dto.Nombre is null && dto.Telefono is null &&
            dto.Email is null && dto.FechaNacimiento is null && dto.Direccion is null)
            return BadRequest(new { Message = "Debe enviar al menos un campo para actualizar." });

        Paciente? paciente = _service.Update(id, dto);
        if (paciente is null)
            return NotFound(new { Message = "Paciente no encontrado." });
        return Ok(new { Message = "Paciente actualizado correctamente." });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        bool eliminado = _service.Delete(id);
        if (!eliminado)
            return NotFound(new { Message = "Paciente no encontrado." });
        return NoContent();
    }
}