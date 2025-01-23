using ExamCode.BL.DTOs;

namespace ExamCode.MVC.HomeVMs
{
    public class HomeVM
    {
        ICollection<PlanViewItemDto> Plans { get; set; }
        ICollection<MemberViewItemDto> Members { get; set; }
    }
}
