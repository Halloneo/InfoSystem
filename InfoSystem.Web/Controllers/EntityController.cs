using System.Collections.Generic;
using InfoSystem.Core.Entities.Basic;
using InfoSystem.Infrastructure.DataBase.Context;
using InfoSystem.Infrastructure.DataBase.Repos;
using InfoSystem.Infrastructure.DataBase.ReposInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace InfoSystem.Web.Controllers
{
	/// <inheritdoc />
	[Route("[controller]/[action]")]
	public class EntityController : Controller
	{
		/// <inheritdoc />
		public EntityController()
		{
			_repository = new EntityRepository(new InfoSystemDbContext());
		}

		/// <summary>
		/// Add a new instance of type <paramref name="typeName"/>.
		/// </summary>
		/// <param name="typeName">Entity type name.</param>
		/// <returns>ActionResult, depending on operation result.</returns> 
		[HttpPost]
		public IActionResult Add([FromQuery] string typeName)
		{
			if (!_repository.Add(typeName))
				return BadRequest();
			return Ok();
		}

		/// <summary>
		/// Gets entity by it's id.
		/// </summary>
		/// <param name="id">Id of an entity instance.</param>
		/// <returns>Entity instance.</returns>
		[HttpGet]
		public Entity Get([FromQuery] int id)
		{
			return _repository.GetById(id);
		}

		/// <summary>
		/// Get all instances of one type.
		/// </summary>
		/// <param name="typeId">Entity type id.</param>
		/// <returns>Entities collection of one type.</returns>
		[HttpGet]
		public IEnumerable<Entity> GetByType([FromQuery] int typeId)
		{
			return _repository.GetByTypeId(typeId);
		}

		private readonly IEntityRepository _repository;
	}
}