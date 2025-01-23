using FluentValidation;

namespace ExamCode.BL.DTOs;

public record PlanCreateDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}


public class PlanCreateDtoValidation : AbstractValidator<PlanCreateDto>
{
    public PlanCreateDtoValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("bos olmamalidir")
            .MaximumLength(50).WithMessage("uzunlugu 50 olmalidir")
            .MinimumLength(2).WithMessage("minimum 2 olmalidir");

        RuleFor(x => x.Description)
     .NotEmpty().WithMessage("bos olmamalidir")
     .MaximumLength(100).WithMessage("uzunlugu 100 olmalidir")
     .MinimumLength(2).WithMessage("minimum 2 olmalidir");

        RuleFor(x => x.Price)
     .NotEmpty().WithMessage("bos olmamalidir");
 

 


    }
}