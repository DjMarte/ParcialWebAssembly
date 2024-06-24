using Shared.Interfaces;
using Shared.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace ParcialWebAssembly.Client.Services
{
	public class ArticuloService(HttpClient httpClient) : IClientService<Articulos>
	{
		public async Task<List<Articulos>> GetAllAsync() {
			var resultado = await httpClient.GetAsync("api/Articulos");
			if (resultado.IsSuccessStatusCode)
				return (await resultado.Content.ReadFromJsonAsync<List<Articulos>>())!;

			return null!;
		}

		public async Task<Articulos> GetByIdAsync(int id) {
			var resultado = (await httpClient.GetAsync($"api/Articulos/{id}"))!;

			if (resultado.IsSuccessStatusCode)
				return (await resultado.Content.ReadFromJsonAsync<Articulos>())!;

			return null!;
		}

		//
		public async Task<bool> ExisteDescripcionAsync(int id, string descripcion) {
			var response = await httpClient.GetAsync($"api/articulos/existe-descripcion?id={id}&descripcion={descripcion}");
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadFromJsonAsync<bool>();
		}

		public async Task<Articulos> CreateAsync(Articulos articulo) {
			var resultado = await httpClient.PostAsJsonAsync("api/Articulos", articulo);

			if (resultado.IsSuccessStatusCode)
				return (await resultado.Content.ReadFromJsonAsync<Articulos>())!;

			return null!;
		}

		public async Task<bool> UpdateAsync(int id, Articulos articulo) {
			var resultado = await httpClient.PutAsJsonAsync($"api/Articulos/{id}", articulo);
			return resultado.IsSuccessStatusCode;
		}

		public async Task<bool> DeleteAsync(int id) {
			var resultado = await httpClient.DeleteAsync($"api/Articulos/{id}");
			return resultado.IsSuccessStatusCode;
		}
	}
}