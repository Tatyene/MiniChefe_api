using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemasDeReceitasMiniChefeAPI.Models;
using SistemasDeReceitasMiniChefeAPI.Repositorios.interfaces;

namespace SistemasDeReceitasMiniChefeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitasController : ControllerBase
    {
        private readonly IReceitaRepositorio _receitaRepositorio;

        public ReceitasController(IReceitaRepositorio receitaRepositorio)
        {
            _receitaRepositorio = receitaRepositorio;
        }

        /// <summary>
        /// Busca todos as receitas
        /// </summary>

        [HttpGet]
        public async Task<ActionResult<List<ReceitaModel>>> TodasReceitas()
        {
            List<ReceitaModel> receitas = await _receitaRepositorio.BuscarTodasReceitas();
            return Ok(receitas);
        }


        /// <summary>
        /// Busca por id receitas
        /// </summary>

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ReceitaModel>>> BuscarPorId(int id)
        {
            ReceitaModel receitas = await _receitaRepositorio.BuscarReceitaPorId(id);
            return Ok(receitas);
        }


        /// <summary>
        /// Cadastra uma receitas
        /// </summary>

        [HttpPost]
        public async Task<ActionResult<ReceitaModel>> CadastrarReceitas([FromBody] ReceitaModel receitaModel)
        {
            ReceitaModel receitas = await _receitaRepositorio.CadastrarReceita(receitaModel);

            return Ok(receitas);
        }


        /// <summary>
        /// Atualiza os dados do receita
        /// </summary>

        [HttpPut("{id}")]
        public async Task<ActionResult<ReceitaModel>> AtualizarReceitas([FromBody] ReceitaModel receitaModel, int id)
        {
            receitaModel.id = id;
            ReceitaModel receita = await _receitaRepositorio.Atualizar(receitaModel, id);
            return Ok(receita);
        }


        /// <summary>
        /// Apaga a receita por id
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReceitaModel>> Apagar(int id)
        {
            bool apagar = await _receitaRepositorio.Apagar(id);
            return Ok(apagar);
        }
    }
}
