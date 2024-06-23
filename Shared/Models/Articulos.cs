using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
	public class Articulos
	{
		[Key]
		public int ArticuloId { get; set; }

		[RegularExpression(@"^[a-zA-Z0-9ñÑ\s]+$")]
		[Required(ErrorMessage = "Descripcion obligatorio")]
		public string? Descripcion { get; set; }

		[Range(0.01, 1000000, ErrorMessage = "Ingrese un valor mayor a 0.01 y menor o igual a 1000000")]
		[Required(ErrorMessage = "Costo obligatorio")]
		public double Costo { get; set; }

		[Range(0, 100, ErrorMessage = "Solo se permite de 0 a 100")]
		[Required(ErrorMessage = "Ganancia obligatoria")]
		public double Ganancia { get; set; }

		[Range(0.01, 1000000, ErrorMessage = "Ingrese un valor mayor a 0.01 y menor o igual a 1000000")]
		[Required(ErrorMessage = "Precio obligatorio")]
		public double Precio { get; set; }
	}
}