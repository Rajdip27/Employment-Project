using AutoMapper;
using Employment.Model.Entities;
using Employment.Service.Models.ViewModel;

namespace Employment.Core.Mappers;

public class CommonMapper : Profile
{
    public CommonMapper()
    {
        CreateMap<VMCountry, Country>().ReverseMap();
        CreateMap<City, VMCity>().ForMember(x => x.StateName, x => x.MapFrom(x => x.States.StateName)).ReverseMap();
        CreateMap<VMState, State>().ReverseMap().ForMember(x => x.CountryName, x => x.MapFrom(x =>
            x.Country != null ? x.Country.CountryName : ""
       ));
        CreateMap<Employee, VMEmployee>().
             ForMember(x => x.CountryName, x => x.MapFrom(x => x.Country.CountryName)).
             ForMember(x => x.StateName, x => x.MapFrom(x => x.State.StateName)).
             ForMember(x => x.CityName, x => x.MapFrom(x => x.City.CityName)).
             ForMember(x => x.DepartmentName, x => x.MapFrom(x => x.Department.DepartmentName)).ReverseMap();
        CreateMap<VMDepartment, Department>().ReverseMap();
    }
}
