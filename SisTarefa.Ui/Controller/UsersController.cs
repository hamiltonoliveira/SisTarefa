using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SisTarefa.Api.Helpers;
using SisTarefa.Api.Interfaces;
using SisTarefa.Domain.Dto;
using SisTarefa.Domain.Entities;
using SisTarefa.Infra.Data.Data;
using SisTarefa.Infra.Data.Interfaces;

namespace SisTarefa.Ui.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        
        private readonly IAutenticarService _autenticarService;
        private readonly IUsersService _usersService;
        private readonly IColaboratorsService _colaboratorsService;
         

        private readonly IMapper _mapper;
       
        public UsersController(IMapper mapper, IAutenticarService autenticarService, IUsersService usersService, IColaboratorsService colaboratorsService) 
        {
             _mapper = mapper;
            _autenticarService = autenticarService;
            _usersService = usersService;
            _colaboratorsService = colaboratorsService;
         }

        [HttpPost("Criar")]
        public async Task<IActionResult> Criar([FromBody] UsersDto usersDto)
        {
            Users users = _mapper.Map<Users>(usersDto);
            users.Password = Criptograph.Encrypt(usersDto.Password);
          

            try
            {
                var _idUsers = await _usersService.InsertAsync(users);
                var Colaborators = new Colaborators(_idUsers.Id, usersDto.UserName);

                await _colaboratorsService.InsertAsync(Colaborators);

            }
            catch (DbUpdateException ex)
            {
                // Obtenha a exceção interna para mais detalhes
                Exception excecaoInterna = ex.InnerException;

                // Lide ou registre a exceção conforme necessário
                // ...
            }

            var token = _autenticarService.GerarToKen(usersDto.UserName);

            var TokensViewModel = new
            {
                //Token = token,
                //TokenRefresh = token,
            };
            return Ok(TokensViewModel);
        }
    }
}
