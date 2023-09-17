using AutoMapper;
using Employment.Repositories.Interface;
using Employment.Service.Models.ViewModel;
using Employment.Sheared.Models;
using FluentValidation;
using MediatR;

namespace Employment.Core.CQRS.Employee.Command;

public record UpdateEmployeeCommand(int id, VMEmployee employee):IRequest<CommandResult<VMEmployee>>;

public class UpdateEmployeeCommandHandeler : IRequestHandler<UpdateEmployeeCommand, CommandResult<VMEmployee>>
{
	private readonly IEmployeeRepository _employeeRepository;
	private readonly IMapper _mapper;
	private readonly IValidator<UpdateEmployeeCommand> _validator;
	public UpdateEmployeeCommandHandeler(IEmployeeRepository employeeRepository,IMapper mapper,IValidator<UpdateEmployeeCommand> validator)
	{
		_employeeRepository = employeeRepository;
		_mapper = mapper;
		_validator = validator;
	}

	public async Task<CommandResult<VMEmployee>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
	{
		var validate= await _validator.ValidateAsync(request, cancellationToken);
		if (!validate.IsValid) throw new ValidationException(validate.Errors);
        if (request.employee.PictureFile?.Length > 0)
        {
            if (request.employee.PictureFile != null && request.employee.PictureFile.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/profiles", request.employee.PictureFile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    request.employee.PictureFile.CopyTo(stream);
                }
                request.employee.Picture = $"{request.employee.PictureFile.FileName}";
            }
        }
        var result =  await _employeeRepository.UpdateAsync(request.id, _mapper.Map<Model.Entities.Employee>(request.employee));
		;
		return result switch { 
		null => new CommandResult<VMEmployee>(null,CommandResultTypeEnum.UnprocessableEntity),
		_ => new CommandResult<VMEmployee>(result,CommandResultTypeEnum.Success)
		};

	}
}
