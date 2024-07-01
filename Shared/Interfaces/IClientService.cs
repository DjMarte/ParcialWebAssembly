using Shared.Models;

namespace Shared.Interfaces;

public interface IClientService<T>
{
	public Task<List<T>> GetAllAsync();
	public Task<T> GetByIdAsync(int id);
	public Task<T> CreateAsync(T articulo);
	public Task<bool> UpdateAsync(T articulo);
	public Task<bool> DeleteAsync(int id);
}