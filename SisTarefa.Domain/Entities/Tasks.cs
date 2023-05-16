using FluentValidation;
using SisTarefa.Domain.Dto;

namespace SisTarefa.Domain.Entities
{
    public class Tasks : Base
    {
        public int UsersId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Projects> Projects { get; set; }
        public Tasks(string? name, string? description)
        {
            Name = name;
            Description = description;
            Projects = new List<Projects>();
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
