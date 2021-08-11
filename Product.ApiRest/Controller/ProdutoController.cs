using Microsoft.AspNetCore.Mvc;

namespace Product.ApiRest.Controller
{
	[ApiController]
	[Controller]
	public class ProdutoController : ControllerBase
	{

		[HttpGet]
		public IActionResult FindAll()
		{
			return Ok();
		}

		[HttpGet("{id}")]
		public IActionResult FindById(int id)
		{
			return Ok();
		}

		[HttpPost]
		public IActionResult Create()
		{
			return Ok();
		}
		
		[HttpPut("{id}")]
		public IActionResult Update(int id )
		{
			return Ok();
		}

		[HttpPatch("{id}")]

		public IActionResult Patch(int id)
		{
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult Delite(int id)
		{
			return Ok();
		}
	}
}
