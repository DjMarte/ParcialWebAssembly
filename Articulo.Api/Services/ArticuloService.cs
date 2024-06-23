using Articulo.Api.DAL;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System.Linq.Expressions;

namespace Articulo.Api.Services;

public class ArticuloService(Contexto contexto)
{
	public async Task<bool> Guardar(Articulos articulo) {
		if(! await Existe(articulo.ArticuloId))
			return await Insertar(articulo);
		else
			return await Modificar(articulo);
	}

	private async Task<bool> Existe(int articuloId) {
		return await contexto.Articulos
			.AnyAsync(a => a.ArticuloId == articuloId);
	}

	public async Task<bool> ExisteDescripcion(int id, string descripcion) {
		return await contexto.Articulos.AnyAsync(a => a.ArticuloId != id 
		&& a.Descripcion.ToLower().Equals(descripcion.ToLower()));
	}

	private async Task<bool> Insertar(Articulos articulo) {
		contexto.Articulos.Add(articulo);
		return await contexto.SaveChangesAsync() > 0;
	}

	private async Task<bool> Modificar(Articulos articulo) {
		contexto.Articulos.Update(articulo);
		var modificado = await contexto.SaveChangesAsync() > 0;
		contexto.Entry(articulo).State = EntityState.Detached;
		return modificado;
	}

	public async Task<bool> Eliminar(Articulos articulo) {
		return await contexto.Articulos
			.AsNoTracking()
			.Where(a => a.ArticuloId == articulo.ArticuloId)
			.ExecuteDeleteAsync() > 0;
	}

	public async Task<Articulos?> Buscar(int id) {
		return await contexto.Articulos
			.AsNoTracking()
			.FirstOrDefaultAsync(a => a.ArticuloId == id);
	}

	public async Task<List<Articulos>> Listar(Expression<Func<Articulos, bool>> criterio) {
		return await contexto.Articulos
			.AsNoTracking()
			.Where(criterio)
			.ToListAsync();
	}
}
