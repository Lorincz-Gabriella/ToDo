using FluentValidation;
using ToDo.Application.DTOs;

namespace ToDo.Application.Validation
{
    public class UpdateToDoItemValidator : AbstractValidator<UpdateToDoItemDTO>
    {
        public UpdateToDoItemValidator() 
        {
            RuleFor(DTO => DTO.Title).NotEmpty().WithMessage("Title can not be empty!").MaximumLength(100).WithMessage("Title can not be 100 char");
            RuleFor(DTO => DTO.Description).NotEmpty().WithMessage("Description can not be empty!").MaximumLength(500).WithMessage("Description can not be more than 500 char");
            RuleFor(DTO => DTO.DeadLine).GreaterThan(DateTime.UtcNow).WithMessage("Deadline must be in the future.");
        }
    }
}
