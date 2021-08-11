using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product.ApiRest.Model
{
	[Table("produto")]
	public class Produto
	{
	
		[Column("id")]
		public int Id { get; set; }

		[Column("name")]
		public string Name { get; set; }

		[Column("sobre_name")]
		public string  SobreName { get; set; }

		[Column("value")]
		public decimal Value { get; set; }

	}
}
