using ExamCode.BL.DTOs;
using ExamCode.DAL.Models;

namespace ExamCode.BL.Services.Abstractions
{
    public interface IPlanService
    {
        Task<ICollection<PlanViewItemDto>> GetPlanViewItemsAsync();
        Task<ICollection<PlanListItemDto>> GetPlanListAsync();
        Task<ICollection<PlanViewItemDto>> GetByIdChildrenViewAsync();        
        Task<MemberUpdateDto> GetByIdForUpdate(int id);
        Task<Plan> GetByIdAsync(int id);
        Task CreateAsync(int id);
        Task UpdateAsync(PlanUpdateDto planUpdateDto);
        Task DeleteAsync(int id);
        Task<int> SaveChangeAsync();
    }
}
