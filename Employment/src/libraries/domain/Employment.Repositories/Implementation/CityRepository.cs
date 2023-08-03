using AutoMapper;
using Employment.DataAccess.Contracts.CommonInterface.BaseInterface;
using Employment.DataAccess.DatabaseContext;
using Employment.Model.Entities;
using Employment.Service.Models.ViewModel;

namespace Employment.Repositories.Implementation;

public class CityRepository : RepositoryBase<City, VMCity, int>
{
	public CityRepository(EmploymentDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
	{
	}
}
