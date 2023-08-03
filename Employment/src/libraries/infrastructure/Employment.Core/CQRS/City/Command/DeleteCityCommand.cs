using Employment.Service.Models.ViewModel;
using Employment.Sheared.Models;
using MediatR;

namespace Employment.Core.CQRS.City.Command;
public record DeleteCityCommand(int Id):IRequest<CommandResult<VMCity>>;

public class DeleteCityCommandHandeler : IRequestHandler<DeleteCityCommand, CommandResult<VMCity>>
{
	public Task<CommandResult<VMCity>> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}
}

