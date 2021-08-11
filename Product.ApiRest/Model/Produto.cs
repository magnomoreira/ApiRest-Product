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

		[Column("type")]
		public string  Type { get; set; }

		[Column("value")]
		public decimal Value { get; set; }

	}
}
