using FluentValidation;
using SisTarefa.Domain.Dto;
using SisTarefa.Domain.Enums;
using System;
using System.Globalization;
using System.Text.Json.Serialization;

namespace SisTarefa.Domain.Entities
{
    public class Users : Base
    {
        public string? UserName { get; set; }

        [JsonIgnore]
        public string? Password { get; set; }

        public string? GuidI { get; set; } = Guid.NewGuid().ToString();

        public string? Email { get; set; }

        public TipoFuncionario Role { get; set; }

        public Colaborators Colaborators { get; set; }

        public void SetDeletar() => DeletedAt = DateTime.UtcNow;

        public void SetUserName(string email)
        {
            if(email != null)
            {
                string[] partes = email.Split('@');
                this.UserName = partes[0].ToLower();
            }
        }
        public class UsersValidation : AbstractValidator<UsersDto>
        {
            public UsersValidation()
            {
                RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("O campo Name não pode ser nulo");
                RuleFor(x => x.Password).NotEmpty().WithMessage("O campo Password não pode ser nulo"); 
                RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("O campo de Email é obrigatório.").EmailAddress().WithMessage("O campo de email não possui um formato válido.");
                RuleFor(x => x.Role).NotNull().NotEmpty().WithMessage("O campo Role não pode ser nulo");
            }
        }
    }
}
