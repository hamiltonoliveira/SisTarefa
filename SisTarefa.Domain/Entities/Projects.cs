using FluentValidation;
using SisTarefa.Domain.Dto;

namespace SisTarefa.Domain.Entities
{
    public class Projects : Base
    {
        public int UsersId { get; set; }
        public string? Name { get; private set; }
        public Projects(string? name)
        {
            Name = name;
        }
        public class ProjectsValidation : AbstractValidator<ProjectsDto>
        {
            public ProjectsValidation()
            {
                RuleFor(x => x.UsersId).NotNull().NotEmpty().WithMessage("UserId não pode ser nulo");
                RuleFor(x => x.Name).MaximumLength(250).NotNull().WithMessage("Name não pode ser nulo e o limite é até 250 caracter");
            }
        }
    }
 }
