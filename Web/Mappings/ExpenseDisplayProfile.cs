using AutoMapper;
using ProjektHaushaltsbuch.Models;
using ProjektHaushaltsbuch.Web.ViewModels;

namespace ProjektHaushaltsbuch.Web.Mappings;

public class ExpenseDisplayProfile: Profile
{
    public ExpenseDisplayProfile()
    {
        CreateMap<ExpenseModel, ExpenseDisplayViewModel>()
            .ForMember(dest => dest.FormattedSum, 
                opt => opt.MapFrom(src => $"{src.Sum:C}"))
            .ForMember(dest => dest.FormattedDate, 
                opt => opt.MapFrom(src => src.Date.ToString("dd. MMMM yyyy")))
            .ForMember(dest => dest.CategoryName, 
                opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.PaymentMethodDisplay, 
                opt => opt.MapFrom(src => src.PaymentMethod.ToString()))
            .ForMember(dest => dest.HasAttachments, 
                opt => opt.MapFrom(src => src.AttachmentUrls != null && src.AttachmentUrls.Any()))
            .ForMember(dest => dest.AttachmentCount, 
                opt => opt.MapFrom(src => src.AttachmentUrls != null ? src.AttachmentUrls.Count : 0))
            .ForMember(dest => dest.TimeAgo, 
                opt => opt.MapFrom(src => GetTimeAgo(src.Date)))
            .ForMember(dest => dest.StatusDisplay, 
                opt => opt.MapFrom(src => src.IsPlanned ? "Geplant" : "Ausgegeben"));
    }
    private string GetTimeAgo(DateTime date)
    {
        var timeSpan = DateTime.Now - date;
        if (timeSpan.Days > 0) return $"vor {timeSpan.Days} Tagen";
        return timeSpan.Hours > 0 ? $"vor {timeSpan.Hours} Stunden" : "vor wenigen Minuten";
    }
}