using AutoMapper;
using ExamCode.BL.DTOs;
using ExamCode.DAL.Models;

namespace ExamCode.BL.Profiles;

public class PlanProfile : Profile
{
    public PlanProfile()
    {
        CreateMap<PlanCreateDto, Plan>().ReverseMap();
        CreateMap<PlanUpdateDto, Plan>().ReverseMap();
        CreateMap<PlanListItemDto, Plan>().ReverseMap();
        CreateMap<PlanViewItemDto, Plan>().ReverseMap();
    }
}
