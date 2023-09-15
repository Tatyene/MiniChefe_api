using Microsoft.AspNetCore.Mvc;
using MiniChefe.DataAccess;
using MiniChefe.Models;

namespace MiniChefe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        UsuarioService usuarioService;
        public UsuarioController()
        {
            usuarioService = new UsuarioService();
        }
        [HttpPost]
        public Usuario PostUsuario(Usuario usuario)
        {
            return usuarioService.Incluir(usuario);
        }

        [HttpDelete("{id}")]
        public bool DeletarUsuario(int id)
        {
            return usuarioService.RemoverUsuario(id);
        }
    }
}
