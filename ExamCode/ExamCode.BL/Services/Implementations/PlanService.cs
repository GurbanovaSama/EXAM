using AutoMapper;
using ExamCode.BL.DTOs;
using ExamCode.BL.Exceptions;
using ExamCode.BL.Services.Abstractions;
using ExamCode.DAL.Models;
using ExamCode.DAL.Repository.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ExamCode.BL.Services.Implementations
{
    [Area("Admin")]

    public class PlanService : IPlanService
    {
        readonly IRepository<Plan> _planRepo;

        public PlanService(IRepository<Plan> planRepo, IMapper mapper)
        {
            _planRepo = planRepo;
            _mapper = mapper;
        }

        readonly IMapper _mapper;


        public async Task CreateAsync(int id)
        {
            Plan plan = _mapper.Map<Plan>(await GetByIdAsync(id));  

           await  _planRepo.CreateAsync(plan);        
        }

        public async Task DeleteAsync(int id)
        {
            Plan plan = _mapper.Map<Plan>(await GetByIdChildrenViewAsync());

             _planRepo.Delete(plan);
        }

        public async Task<Plan> GetByIdAsync(int id) => await _planRepo.GetByIdAsync(id);

        public async Task<ICollection<PlanViewItemDto>> GetByIdChildrenViewAsync() => _mapper.Map<ICollection<PlanViewItemDto>>(await _planRepo.GetAllAsync("member"));

        public async Task<MemberUpdateDto> GetByIdForUpdate(int id) => _mapper.Map<MemberUpdateDto>(await _planRepo.GetAllAsync());

        public async Task<ICollection<PlanListItemDto>> GetPlanListAsync() => _mapper.Map<ICollection<PlanListItemDto>>(await _planRepo.GetAllAsync());

        public async Task<ICollection<PlanViewItemDto>> GetPlanViewItemsAsync()=> _mapper.Map<ICollection<PlanViewItemDto>>(await _planRepo.GetAllAsync());         

        public async Task<int> SaveChangeAsync()=> await _planRepo.SaveChangeAsync();   

        public async Task UpdateAsync(PlanUpdateDto planUpdateDto)
        {
            Plan oldPlan = await GetByIdAsync(planUpdateDto.Id);
            Plan plan = _mapper.Map<Plan>(await _planRepo.GetByIdAsync(planUpdateDto.Id));   
            plan.CreatedAt = oldPlan.CreatedAt;

            _planRepo.Update(plan);

  
        }
    }
}
