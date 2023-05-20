using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SisTarefa.Api.Helpers;
using SisTarefa.Api.Interfaces;
using SisTarefa.Domain.Dto;
using SisTarefa.Domain.Entities;
using SisTarefa.Infra.Data.Data;
using static SisTarefa.Domain.Entities.Users;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace SisTarefa.Ui.Controller
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly IAutenticarService _autenticarService;
        private readonly IUsersService _usersService;
        private readonly IColaboratorsService _colaboratorsService;

        protected readonly DataContext _db;

        private readonly IMapper _mapper;

        public UsersController(DataContext db, IMapper mapper, IAutenticarService autenticarService, IUsersService usersService, IColaboratorsService colaboratorsService)
        {
            _db = db;
            _mapper = mapper;
            _autenticarService = autenticarService;
            _usersService = usersService;
            _colaboratorsService = colaboratorsService;
        }

        [AllowAnonymous]
        [HttpPost("Criar")]
        [ProducesResponseType(typeof(UsersDto), 201)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Criar([FromBody] UsersDto usersDto)
        {
            UsersValidation validator = new UsersValidation();
            var validationResult = validator.Validate(usersDto);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                return BadRequest(errors);
            }

   
            Users users = _mapper.Map<Users>(usersDto);
            users.Password = Criptograph.Encrypt(usersDto.Password);
            users.SetUserName(users.Email);
            TokensDto tokens = null;

            try
            {
                List<Users> usuarios = await _usersService.WhereAsync(x => x.Email == usersDto.Email);

                if (usuarios.Count == 0)
                {
                    var _idUsers = await _usersService.InsertAsync(users);
                    var Colaborators = new Colaborators(_idUsers.Id, _idUsers.UserName);
                    await _colaboratorsService.InsertAsync(Colaborators);
                    tokens = await _autenticarService.GerarToKen(usersDto.Email);
                }

            }
            catch (DbUpdateException ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Message = "Ocorreu um erro ao criar o usuário.",
                    ErrorCode = "CREATE_USER_ERROR"
                };
                return BadRequest(errorResponse);
            }
            return Ok(tokens);
        }

        [Authorize(Roles = "Gerente")]
        [HttpGet("DadosUsuario")]
        [ProducesResponseType(typeof(IEnumerable<UsersDto>), 200)]
        public IActionResult DadosUsuario()
        {
            var claims = User.Claims.GetEnumerator();
            var claims1 = User.Claims.Select(claim => new { claim.Type, claim.Value }).ToArray();
            string Guid = string.Empty;
            int exp = 0;

            foreach (var item in claims1)
            {
                if (item.Type == "Guid")
                {
                    Guid = item.Value;
                }
                if (item.Type == "exp")
                {
                    exp = int.Parse(item.Value);
                    break;
                }
            }

            //DateTimeOffset expirationTime = DateTimeOffset.FromUnixTimeSeconds(exp);
            //DateTime localDateTime = expirationTime.LocalDateTime;

            //bool isExpired = DateTimeOffset.Now > localDateTime;

            //if (isExpired)
            //{
            //    return BadRequest("Token expirado.");
            //}

            var query = from user in _db.Users
                        join collaborator in _db.Colaborators on user.Id equals collaborator.Id
                        where user.GuidI == Guid
                        select new
                        {
                            UserId = user.Id,
                            UserName = user.UserName,
                            Email = user.Email
                        };

            return Ok(query);
        }
    }
     
}
