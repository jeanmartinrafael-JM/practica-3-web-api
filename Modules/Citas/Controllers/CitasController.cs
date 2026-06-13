using Microsoft.AspNetCore.Mvc;
using ReservaCitasMedicasJ.Modules.Citas.Dtos;
using ReservaCitasMedicasJ.Modules.Citas.Services;

namespace ReservaCitasMedicasJ.Modules.Citas.Controllers
{
    [ApiController]
    [Route("citas")]
    public class CitasController : ControllerBase
    {
        private readonly CitasService _service;

        public CitasController(CitasService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            return Ok(_service.ObtenerTodos());
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(Guid id)
        {
            var cita = _service.ObtenerPorId(id);
            if (cita is null) return NotFound("Cita no encontrada.");
            return Ok(cita);
        }

        [HttpPost]
        public IActionResult Crear([FromBody] CrearCitaDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Paciente) ||
                string.IsNullOrWhiteSpace(dto.Doctor) ||
                string.IsNullOrWhiteSpace(dto.Motivo))
                return BadRequest("Los campos Paciente, Doctor y Motivo son obligatorios.");

            var cita = _service.Crear(dto);
            return Created($"/citas/{cita.Id}", cita);
        }

        [HttpPatch("{id}")]
        public IActionResult Actualizar(Guid id, [FromBody] ActualizarCitaDto dto)
        {
            if (dto.Paciente is null && dto.Doctor is null &&
                dto.Fecha is null && dto.Motivo is null && dto.Estado is null)
                return BadRequest("Debe enviar al menos un campo para actualizar.");

            var cita = _service.Actualizar(id, dto);
            if (cita is null) return NotFound("Cita no encontrada.");
            return Ok(cita);
        }

        [HttpDelete("{id}")]
        public IActionResult Eliminar(Guid id)
        {
            var eliminado = _service.Eliminar(id);
            if (!eliminado) return NotFound("Cita no encontrada.");
            return Ok("Cita eliminada correctamente.");
        }
    }
}