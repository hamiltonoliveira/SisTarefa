using FluentValidation;
using SisTarefa.Domain.Dto;

namespace SisTarefa.Domain.Entities
{
    public class Colaborators : Base
    {
        public int UsersId { get; set; }
        public virtual Users Users { get; set; }
        public string? Name { get; set; }

        public ICollection<TimeTraCkers> TimeTraCkers { get; set; }

        public Colaborators(int usersId, string? name)
        {
            UsersId = usersId;
            Name = name;
        }
        public class ColaboratorsValidation : AbstractValidator<ColaboratorsDto>
        {
            public ColaboratorsValidation()
            {
                RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Name não pode ser nulo");
            }
        }
    }
}
