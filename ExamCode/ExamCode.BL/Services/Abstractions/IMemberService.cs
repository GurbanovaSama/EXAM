using ExamCode.BL.DTOs;
using ExamCode.DAL.Models;

namespace ExamCode.BL.Services.Abstractions
{
    public interface IMemberService
    {
        Task<ICollection<MemberViewItemDto>> GetMemberViewItemsAsync(); 
        Task<ICollection<MemberListItemDto>> GetMemberListAsync();
        Task<MemberUpdateDto> GetByIdForUpdate(int id);        
        Task<Member> GetByIdAsync(int id);
        Task CreateAsync(int id);       
        Task UpdateAsync(MemberUpdateDto memberUpdateDto);
        Task DeleteAsync(int id);
        Task<int> SaveChangeAsync();

    }
}
