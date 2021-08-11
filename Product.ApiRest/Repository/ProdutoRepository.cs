using Product.ApiRest.DataDbContext;
using Product.ApiRest.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Product.ApiRest.Repository
{
	public class ProdutoRepository
	{
		private readonly ProdutoApplication _application;

		public ProdutoRepository( ProdutoApplication application )
		{
			_application = application;
		}

		public IList<Produto> FindAll()
		{

			return _application.Produtos.ToList();
		}

		public Produto FindById( int id)
		{
			var produto = _application.Produtos.SingleOrDefault(p => p.Id.Equals(id));
			return produto;
		}

		public Produto Create(Produto produto)
		{
			try
			{
				_application.Add(produto);
				_application.SaveChanges();

			}
			catch (Exception)
			{

				throw;
			}
			return produto;
		}

		public Produto Update(Produto produto)
		{
			var result = _application.Produtos.SingleOrDefault(p => p.Id.Equals(produto.Id));

			if (result != null)
			{
				try
				{
					_application.Entry(result).CurrentValues.SetValues(produto);
					_application.SaveChanges();

				}
				catch (Exception)
				{

					throw;
				}
				
			}

			return produto;
		}

		public void Delete( int id)
		{
			var produtoDelite = _application.Produtos.SingleOrDefault(p => p.Id.Equals(id));

			if (produtoDelite != null)
			{
				try
				{
					_application.Remove(produtoDelite);
					_application.SaveChanges();

				}
				catch (Exception)
				{

					throw;
				}
			}
		}

		//public bool Disable(Produto produto)
		//{
		//	var result = _application.Produtos.SingleOrDefault(p => p.Id.Equals(produto.Id));

		//	if( result != null)
		//	{
		//		try
		//		{
		//			produto.Enable = false;

		//		}
		//		catch (Exception)
		//		{

		//			throw;
		//		}
		//	}
		//	return true;
		//}
	}
}
