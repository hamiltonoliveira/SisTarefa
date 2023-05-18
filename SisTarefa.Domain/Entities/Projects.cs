using FluentValidation;
using SisTarefa.Domain.Dto;

namespace SisTarefa.Domain.Entities
{
    public class Projects : Base
    {
        public string? Name { get; private set; }
        public ICollection<Tasks> Tasks { get; set; }
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
