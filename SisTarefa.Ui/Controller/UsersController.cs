using Microsoft.AspNetCore.Mvc;
using SisTarefa.Api.Interfaces;
using SisTarefa.Api.Services;
using SisTarefa.Domain.Dto;
using System.Diagnostics;

namespace SisTarefa.Ui.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IAutenticarService _autenticarService;
        private readonly UsersService _usersService;
        public UsersController(IAutenticarService autenticarService, UsersService usersService) 
        {
            _autenticarService = autenticarService;
            //_usersService = usersService;
        }


        [HttpPost("Criar")]
        public async Task<IActionResult> Criar([FromBody] UsersDto usersDto)
        {
            //Usuario usuario = _mapper.Map<Usuario>(usuarioDTO);
            //var validator = new UsuarioValidation();
            //var result = await validator.ValidateAsync(usuarioDTO);

            //List<string> errors = new List<string>();
            //if (!result.IsValid)
            //{
                //foreach (var failure in result.Errors)
                //{
                    //errors.Add(failure.ErrorMessage);
                //}
                //var retorna = String.Join("| ", errors.ToArray());
               // return BadRequest(retorna);
            //}




            //await _usuarioRepositorio.InsertAsync(usuario);
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
