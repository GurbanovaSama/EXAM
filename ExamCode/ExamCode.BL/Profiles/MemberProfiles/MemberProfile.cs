using AutoMapper;
using ExamCode.BL.DTOs;
using ExamCode.DAL.Models;

namespace ExamCode.BL.Profiles;

public class MemberProfile : Profile
{
    public MemberProfile()
    {
        CreateMap<MemberCreateDto, Member>().ReverseMap();  
        CreateMap<MemberUpdateDto, Member>().ReverseMap();
        CreateMap<MemberListItemDto, Member>().ReverseMap();
        CreateMap<MemberViewItemDto, Member>().ReverseMap();

    }
}
