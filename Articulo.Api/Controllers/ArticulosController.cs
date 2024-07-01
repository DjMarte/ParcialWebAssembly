using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Articulo.Api.DAL;
using Shared.Models;
using Articulo.Api.Services;
using System.Formats.Asn1;
using Microsoft.AspNetCore.Http.HttpResults;
using Shared.Interfaces;

namespace Articulo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController(IApiService<Articulos> apiService) : ControllerBase
    {
        // GET: api/Articulos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Articulos>>> GetArticulos()
        {
            return await apiService.GetAllAsync();
        }

		// GET: api/Articulos/5
		[HttpGet("{id}")]
        public async Task<ActionResult<Articulos>> GetArticulos(int id)
        {
            var articulos = await apiService.GetByIdAsync(id);

            if (articulos is null)
                return NotFound($"No se encontró el artículo con ID {id}.");

            return articulos;
        }

		// POST: api/Articulos
		[HttpPost]
		public async Task<ActionResult<Articulos>> PostArticulos(Articulos articulos) {

			var guardado = await apiService.CreateAsync(articulos);

			if (guardado != null)
				return Ok(guardado);

			return NotFound("No se pudo guardar el artículo.");
		}

		// PUT: api/Articulos/5
		[HttpPut("{id}")]
        public async Task<IActionResult> PutArticulos(int id, Articulos articulos)
        {
            if (id != articulos.ArticuloId)
                return BadRequest("El ID del artículo no coincide con el ID de la URL.");

			var modificado = await apiService.UpdateAsync(articulos);
            if (!modificado)
                return NotFound($"No se pudo actualizar el artículo con ID {id}. Puede que el artículo no exista.");

            return NoContent();
        }

        // DELETE: api/Articulos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticulos(int id)
        {
            var articulos = await apiService.DeleteAsync(id);

            if (!articulos)
                return NotFound($"No se pudo eliminar el artículo con ID {id}. Puede que el artículo no exista.");

            return NoContent();
        }
    }
}
