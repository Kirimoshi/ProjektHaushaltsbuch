using AutoMapper;
using ProjektHaushaltsbuch.Models;
using ProjektHaushaltsbuch.Web.ViewModels;

namespace ProjektHaushaltsbuch.Web.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserModel, UserViewModel>()
            .ForMember(dest => dest.TotalExpenses, 
                opt => opt.MapFrom(src => src.Expenses.Count))
            .ForMember(dest => dest.TotalBudgets, 
                opt => opt.MapFrom(src => src.Budgets.Count));
                          
        CreateMap<UserViewModel, UserModel>()
            .ForMember(dest => dest.Expenses, opt => opt.Ignore())
            .ForMember(dest => dest.Budgets, opt => opt.Ignore());
    }
}