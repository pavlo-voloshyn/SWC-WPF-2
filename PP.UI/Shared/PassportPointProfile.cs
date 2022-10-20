using AutoMapper;
using PP.Domain.Models;
using PP.UI.ViewModels;

namespace PP.UI.Shared;

public static class PassportPointProfile
{
    public static MapperConfiguration Initialize()
    {
        return new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            cfg.CreateMap<Order, OrderViewModel>().ReverseMap();
        });
    }
}
