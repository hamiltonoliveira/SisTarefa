using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SisTarefa.Api.Helpers;
using SisTarefa.Api.Interfaces;
using SisTarefa.Domain.Dto;
using SisTarefa.Domain.Entities;

namespace SisTarefa.Ui.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IAutenticarService _autenticarService;
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;
        public UsersController(IMapper mapper, IAutenticarService autenticarService, IUsersService usersService) 
        {
             _mapper = mapper;
            _autenticarService = autenticarService;
            _usersService = usersService;
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Criar([FromBody] UsersDto usersDto)
        {
            Users users = _mapper.Map<Users>(usersDto);
            users.Password = Criptograph.Encrypt(usersDto.Password);
             
            await _usersService.InsertAsync(users);
            var token = _autenticarService.GerarToKen(usersDto.UserName);

            var TokensViewModel = new
            {
                Token = token,
                TokenRefresh = token,
            };
            return Ok(TokensViewModel);
        }



    }
}
