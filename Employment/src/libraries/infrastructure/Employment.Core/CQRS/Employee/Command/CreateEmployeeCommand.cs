using AutoMapper;

using Employment.Repositories.Interface;
using Employment.Service.Models.ViewModel;
using Employment.Sheared.Models;
using FluentValidation;
using MediatR;

namespace Employment.Core.CQRS.Employee.Command;

public record CreateEmployeeCommand(VMEmployee employee):IRequest<CommandResult<VMEmployee>>;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, CommandResult<VMEmployee>>
{
	private readonly IEmployeeRepository _employeeRepository;
	private readonly IValidator<CreateEmployeeCommand> _validator;
	private readonly IMapper _mapper;
	public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper, IValidator<CreateEmployeeCommand> validator)
	{
		_employeeRepository = employeeRepository;
		_mapper = mapper;
		_validator = validator;
	}

	public async Task<CommandResult<VMEmployee>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
	{
		var validate = await _validator.ValidateAsync(request, cancellationToken);
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
        var employee = await _employeeRepository.InsertAsync(_mapper.Map<Model.Entities.Employee>(request.employee));
		;
		return employee switch
		{
			null => new CommandResult<VMEmployee>(null, CommandResultTypeEnum.NotFound),
			_ => new CommandResult<VMEmployee>(employee, CommandResultTypeEnum.Success)
		};
	}
}

