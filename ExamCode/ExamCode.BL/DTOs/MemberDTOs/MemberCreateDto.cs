using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace ExamCode.BL.DTOs;

public record MemberCreateDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Position { get; set; }
    public IFormFile Image { get; set; }
    public int PlanId { get; set; }
}


public class MemberCreateDtoValidation : AbstractValidator<MemberCreateDto>
{
    public MemberCreateDtoValidation()
    {
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