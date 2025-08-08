using FluentValidation;
using ToDo.Application.DTOs;

namespace ToDo.Application.Validation
{
    public class CreateToDoItemValidator: AbstractValidator<CreateToDoItemDTO>
    {
        public CreateToDoItemValidator() 
        {
            RuleFor(DTO => DTO.Title).NotEmpty().WithMessage("Title can not be empty!").MaximumLength(100).WithMessage("Title can not be 100 char");
            RuleFor(DTO => DTO.Description).MaximumLength(500).WithMessage("Description can not be more than 500 char");
            RuleFor(DTO => DTO.DeadLine).GreaterThan(DateTime.UtcNow).WithMessage("Deadline must be in the future.");
        }
    }
}
