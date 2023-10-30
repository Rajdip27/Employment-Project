using Employment.Backend.Controllers.Common;
using Employment.Core.CQRS.Department.Command;
using Employment.Core.CQRS.Department.Query;
using Employment.Service.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Employment.Backend.Controllers;
public class DepartmentController : ApiControllerBase
{
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	[ProducesResponseType(404)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	[HttpGet("{id:int}")]
	public async Task<ActionResult<VMDepartment>> GetById(int id)=> await HandleQueryAsync(new GetDepartmentQueryById(id));
	
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	[ProducesResponseType(404)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	[HttpGet]
	public async Task<ActionResult<VMDepartment>> GetAll()=> await HandleQueryAsync(new GetDepartmentAllQuery());
	
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	[ProducesResponseType(404)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	[HttpPost]
	public async Task<ActionResult<VMEmployee>> Create([FromBody] VMDepartment command)=> await HandleCommandAsync(new CreateDepartmentCommand(command));
	
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	[ProducesResponseType(404)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	[HttpPut("{id:int}")]
	public async Task<ActionResult<VMDepartment>> Update(int id, VMDepartment command)=> await HandleCommandAsync(new UpdateDepartmentCommand(id, command));
	
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	[ProducesResponseType(404)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	[HttpDelete("{id:int}")]
	public async Task<ActionResult<VMDepartment>> Delete(int id)=> await HandleCommandAsync(new DeleteDepartmentCommand(id));
	
}
