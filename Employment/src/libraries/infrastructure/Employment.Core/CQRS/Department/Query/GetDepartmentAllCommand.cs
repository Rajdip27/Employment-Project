using Employment.Repositories.Interface;
using Employment.Service.Models.ViewModel;
using Employment.Sheared.Models;
using MediatR;

namespace Employment.Core.CQRS.Department.Query;

public record GetDepartmentAllCommand():IRequest<QueryResult<IEnumerable<VMDepartment>>>;

public class GetDepartmentAllHandler : IRequestHandler<GetDepartmentAllCommand, QueryResult<IEnumerable<VMDepartment>>>
{
	private readonly IDepartmentRepository _departmentRepository;
	public GetDepartmentAllHandler(IDepartmentRepository departmentRepository) => _departmentRepository = departmentRepository;
	public async Task<QueryResult<IEnumerable<VMDepartment>>> Handle(GetDepartmentAllCommand request, CancellationToken cancellationToken)
	{
		var result = await _departmentRepository.GetAllAsync();
		;
		return result switch
		{
			null => new QueryResult<IEnumerable<VMDepartment>>(null, QueryResultTypeEnum.NotFound),
			_ => new QueryResult<IEnumerable<VMDepartment>>(result, QueryResultTypeEnum.Success),
		} ;
	}
}

