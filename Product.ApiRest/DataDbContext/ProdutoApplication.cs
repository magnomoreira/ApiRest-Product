using Microsoft.EntityFrameworkCore;
using Product.ApiRest.Model;

namespace Product.ApiRest.DataDbContext
{
	public class ProdutoApplication : DbContext
	{

		public ProdutoApplication(DbContextOptions<ProdutoApplication> options) : base(options) { }

		protected ProdutoApplication() { }
		

		public DbSet<Produto> Produtos { get; set; }

	}
}
