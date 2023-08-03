using Employment.Service.Models.ViewModel;
using Employment.Sheared.Models;
using MediatR;

namespace Employment.Core.CQRS.City.Command;

public record UpdateCityCommand(VMCity city):IRequest<CommandResult<VMCity>>;

