using FluentValidation;
using SisTarefa.Domain.Dto;
using System.Text.Json.Serialization;

namespace SisTarefa.Domain.Entities
{
    public class Users : Base
    {
        public string? UserName { get; set; }

        [JsonIgnore]
        public string? Password { get; set; }

        public Users(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
        public class UsersValidation : AbstractValidator<UsersDto>
        {
            public UsersValidation()
            {
                RuleFor(x => x.UserName).MaximumLength(250).NotNull().WithMessage("Name não pode ser nulo e o limite é até 250 caracter");
                RuleFor(x => x.Password).MaximumLength(512).NotEmpty().WithMessage("Password não pode ser nulo");
            }
        }
    }
}
