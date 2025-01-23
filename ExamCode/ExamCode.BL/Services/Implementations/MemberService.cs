using AutoMapper;
using ExamCode.BL.DTOs;
using ExamCode.BL.Exceptions;
using ExamCode.BL.Services.Abstractions;
using ExamCode.DAL.Models;
using ExamCode.DAL.Repository.Abstractions;

namespace ExamCode.BL.Services.Implementations
{
    public class MemberService : IMemberService
    {
        readonly IRepository<Member> _memberRepo;
        readonly IRepository<Plan> _planRepo;
        readonly IMapper _mapper;

        public MemberService(IMapper mapper, IRepository<Plan> planRepo, IRepository<Member> memberRepo)
        {
            _mapper = mapper;
            _planRepo = planRepo;
            _memberRepo = memberRepo;
        }

        public async Task CreateAsync (int id)
        {
            if (await GetByIdAsync(id) is not null) throw new BaseException();
            Member member = _mapper.Map<Member>(id);    
            await _memberRepo.CreateAsync(member);       

        }

        public async Task DeleteAsync(int id)
        {
            Member member = await GetByIdAsync(id);     

            _memberRepo.Delete(member);
        }

        public async Task<Member> GetByIdAsync(int id) => await _memberRepo.GetByIdAsync(id) ?? throw new BaseException();

        public async Task<MemberUpdateDto> GetByIdForUpdate(int id) => _mapper.Map<MemberUpdateDto>(await _memberRepo.GetByIdAsync(id));

        public async Task<ICollection<MemberListItemDto>> GetMemberListAsync() => _mapper.Map<ICollection<MemberListItemDto>>(await _memberRepo.GetAllAsync());   

        public async Task<ICollection<MemberViewItemDto>> GetMemberViewItemsAsync() => _mapper.Map<ICollection<MemberViewItemDto>>(await _memberRepo.GetAllAsync());          

        public async Task<int> SaveChangeAsync() => await _memberRepo.SaveChangeAsync();        

        public async Task UpdateAsync(MemberUpdateDto memberUpdateDto)
        {
            if(await GetByIdAsync(memberUpdateDto.Id) is not null)  throw new BaseException(); 
            
            Member oldMember = await GetByIdAsync(memberUpdateDto.Id);
            Member member = _mapper.Map<Member>(await GetByIdAsync(memberUpdateDto.Id));

            member.CreatedAt = oldMember.CreatedAt;         

              _memberRepo.Update(member);
        }

      
    }
}
