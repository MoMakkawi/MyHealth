using FluentValidation;

namespace MyHealth.Application.Features.Diseases.Commands.CreateDisease;

public class CreateDiseaseCommandValidator : AbstractValidator<CreateDiseaseCommand>
{
    public CreateDiseaseCommandValidator()
    {
        RuleFor(d => d.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("Name of Disease Empty or Null , Please check it ");

        RuleFor(d => d.Discription)
            .NotNull()
            .NotEmpty()
            .WithMessage("Discription of Disease Empty or Null , Please check it ");
    }
}
