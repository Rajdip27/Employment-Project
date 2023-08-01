using Employment.Backend.Controllers.Common;
using Employment.Core.CQRS.Employee.Query;
using Employment.Service.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using static Employment.Core.CQRS.Employee.Query.GetAllEmployee;

namespace Employment.Backend.Controllers
{
	[ApiController]
	public class EmployeeController : ApiControllerBase
	{
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		[ProducesResponseType(401)]
		[ProducesResponseType(403)]
		[HttpGet("{id:int}")]
		public async Task<ActionResult<VMEmployee>> GetById(int id)
		{
			return await HandleQueryAsync(new GetEmployeeByIdQuery(id));
		}
		[HttpGet]
		public async Task<ActionResult<VMEmployee>> GetAllStudent()
		{
			return await HandleQueryAsync(new GetAllEmployeeQuery());
		}

	}
}
