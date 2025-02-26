using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;

namespace UsuariosApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;

        public UsuariosController(IMapper mapper, UserManager<Usuario> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto dto)
        {
            Usuario usuario = _mapper.Map<Usuario>(dto);

            var resultado = await _userManager.CreateAsync(usuario, dto.Password);

            if (resultado.Succeeded)
                return Ok("Usuário cadastrado!");

            throw new ApplicationException("Falha ao cadastrar uauário");
        }
    }
}
