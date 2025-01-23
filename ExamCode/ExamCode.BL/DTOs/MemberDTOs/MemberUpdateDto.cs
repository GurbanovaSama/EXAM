using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace ExamCode.BL.DTOs;

public record MemberUpdateDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Position { get; set; }
    public IFormFile? Image { get; set; }
    public int PlanId { get; set; }
}
public class MemberUpdateDtoValidation : AbstractValidator<MemberUpdateDto>
{
    public MemberUpdateDtoValidation()
    {
        RuleFor(x => x.Id)
  .NotEmpty().WithMessage("bos olmamalidir")
  .GreaterThanOrEqualTo(1).WithMessage("1 ve boyuk olmalidir");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("bos olmamalidir")
            .MaximumLength(50).WithMessage("uzunlugu 50 olmalidir")
            .MinimumLength(2).WithMessage("minimum 2 olmalidir");

        RuleFor(x => x.Surname)
     .NotEmpty().WithMessage("bos olmamalidir")
     .MaximumLength(100).WithMessage("uzunlugu 100 olmalidir")
     .MinimumLength(2).WithMessage("minimum 2 olmalidir");

        RuleFor(x => x.Position)
     .NotEmpty().WithMessage("bos olmamalidir")
     .MaximumLength(50).WithMessage("uzunlugu 50 olmalidir")
     .MinimumLength(2).WithMessage("minimum 2 olmalidir");

        RuleFor(x => x.PlanId)
     .NotEmpty().WithMessage("bos olmamalidir")
     .GreaterThanOrEqualTo(1).WithMessage("1 ve boyuk olmalidir");


    }
}