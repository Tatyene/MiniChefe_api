using Microsoft.AspNetCore.Mvc;
using MiniChefe.DataAccess;
using MiniChefe.Models;

namespace MiniChefe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitaController : Controller
    {
        ReceitaService receitaService;
        public ReceitaController()
        {
            receitaService = new ReceitaService();
        }
        [HttpGet]
        public IEnumerable<Receita> GetReceitas()
        {
            return receitaService.ListarTodas();
        }
    }
}
