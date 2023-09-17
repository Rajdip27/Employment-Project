using Employment.Backend.Controllers.Common;
using Employment.Core.CQRS.City.Command;
using Employment.Core.CQRS.City.Query;
using Employment.Service.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Employment.Backend.Controllers;


public class CityController : ApiControllerBase
{
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	[ProducesResponseType(404)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	[HttpGet("{id:int}")]
	public async Task<ActionResult<VMCity>> GetById(int id)=> await HandleQueryAsync(new GetCityQueryById(id));
	
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	[ProducesResponseType(404)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	[HttpGet]
	public async Task<ActionResult<VMCity>> GetAll()=> await HandleQueryAsync(new GetCityAllQuery());
	
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	[ProducesResponseType(404)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	[HttpPost]
	public async Task<ActionResult<VMCity>> Create([FromBody] VMCity command)=> await HandleCommandAsync(new CreateCityCommand(command));
	
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	[ProducesResponseType(404)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	[HttpPut("{id:int}")]
	public async Task<ActionResult<VMCity>> Update(int id, VMCity command)=> await HandleCommandAsync(new UpdateCityCommand(id, command));
	
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	[ProducesResponseType(404)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	[HttpDelete("{id:int}")]
	public async Task<ActionResult<VMCity>> Delete(int id)=> await HandleCommandAsync(new DeleteCityCommand(id));
	
}
