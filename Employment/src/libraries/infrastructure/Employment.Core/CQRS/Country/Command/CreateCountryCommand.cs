using Employment.Service.Models.ViewModel;
using Employment.Sheared.Models;
using MediatR;

namespace Employment.Core.CQRS.Country.Command;

public record CreateCountryCommand(VMCountry vmCountry) : IRequest<CommandResult<VMCountry>>;
public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, CommandResult<VMCountry>
{
	
	public Task<CommandResult<VMCountry>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}
}
