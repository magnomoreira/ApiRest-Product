using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Product.ApiRest.Model;
using Product.ApiRest.Repository;
using System.Collections.Generic;

namespace Product.ApiRest.Controller
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProdutoController : ControllerBase
	{
		private readonly ILogger<ProdutoController> _logger;
		private  ProdutoRepository _repository;

		public ProdutoController(ILogger<ProdutoController> logger, ProdutoRepository repository)
		{
			_logger = logger;
			_repository = repository;
		}

		[HttpGet]
		[ProducesResponseType((200), Type = typeof(List<Produto>))]
		[ProducesResponseType(204)]
		[ProducesResponseType(400)]
		[ProducesResponseType(401)]
		public IActionResult FindAll()
		{
			var produto = _repository.FindAll();
			return Ok(produto);
		}

		[HttpGet("{id}")]
		[ProducesResponseType((200), Type = typeof(List<Produto>))]
		[ProducesResponseType(204)]
		[ProducesResponseType(400)]
		[ProducesResponseType(401)]
		public IActionResult FindById(int id)
		{

			var produtoId = _repository.FindById(id);
			if (produtoId != null) return NotFound();
			return Ok(produtoId);
		}

		[HttpPost]
		[ProducesResponseType((200), Type = typeof(List<Produto>))]
		[ProducesResponseType(400)]
		[ProducesResponseType(401)]
		public IActionResult Create([FromBody] Produto produto)
		{
			if (produto == null) return BadRequest();
			var produtoCreate = _repository.Create(produto);
			return Ok(produtoCreate);
		}
		
		[HttpPut("{id}")]
		[ProducesResponseType((200), Type = typeof(List<Produto>))]
		
		[ProducesResponseType(400)]
		[ProducesResponseType(401)]
		public IActionResult Update([FromBody] Produto produto)
		{
			var produtoUpdate = _repository.Update(produto);
			return Ok();
		}

		//[HttpPatch("{id}")]

		//public IActionResult Patch(Produto produto)
		//{
		//	var produtoId = _repository.Disable(produto);
		//	return Ok(produtoId);
		//}

		[HttpDelete("{id}")]
		[ProducesResponseType(204)]
		[ProducesResponseType(400)]
		[ProducesResponseType(401)]
		public IActionResult Delete(int id)
		{
			_repository.Delete(id);

			return NoContent();
		}
	}
}
