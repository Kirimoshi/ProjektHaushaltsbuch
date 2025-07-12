using AutoMapper;
using ProjektHaushaltsbuch.Models;
using ProjektHaushaltsbuch.Web.ViewModels;

namespace ProjektHaushaltsbuch.Web.Mappings;

public class ExpenseCreateProfile: Profile
{
    public ExpenseCreateProfile()
    {
        CreateMap<ExpenseCreateViewModel, ExpenseModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id == Guid.Empty ? Guid.NewGuid() : src.Id))
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore()) // Wird durch DB-Default gesetzt
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore()) // Wird durch Business Logic gesetzt
            .ForMember(dest => dest.Tags,
                opt => opt.MapFrom(src => src.Tags != null ? string.Join(",", src.Tags) : null))
            .ForMember(dest => dest.AttachmentUrls,
                opt => opt.MapFrom(src => src.AttachmentUrls != null ? string.Join(",", src.AttachmentUrls) : null))
            .ForMember(dest => dest.User, opt => opt.Ignore()) // Navigation Property - wird nicht gemappt
            .ForMember(dest => dest.Category, opt => opt.Ignore()) // Navigation Property - wird nicht gemappt
            .ForMember(dest => dest.UserId, opt => opt.Ignore()); // Wird durch Business Logic gesetzt
    }
}