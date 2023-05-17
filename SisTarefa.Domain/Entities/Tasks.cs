using FluentValidation;
using SisTarefa.Domain.Dto;

namespace SisTarefa.Domain.Entities
{
    public class Tasks : Base
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int ProjectsId { get; set; }
        public Projects Projects { get; set; }
        public ICollection<TimeTraCkers> TimeTraCkers { get; set; }

        public Tasks(string? name, string? description)
        {
            Name = name;
            Description = description;
        }

        public class TasksValidation : AbstractValidator<TaskDto>
        {
            public TasksValidation()
            {
                RuleFor(x => x.Name).MaximumLength(250).NotNull().WithMessage("Name não pode ser nulo e o limite é até 250 caracter");
                RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage("Description não pode ser nulo");
            }
        }
    }
}
