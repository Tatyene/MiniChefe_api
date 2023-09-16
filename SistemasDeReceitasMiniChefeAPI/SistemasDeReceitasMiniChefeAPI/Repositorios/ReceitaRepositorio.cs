using Microsoft.EntityFrameworkCore;
using SistemasDeReceitasMiniChefeAPI.Data;
using SistemasDeReceitasMiniChefeAPI.Models;
using SistemasDeReceitasMiniChefeAPI.Repositorios.interfaces;

namespace SistemasDeReceitasMiniChefeAPI.Repositorios
{
    public class ReceitaRepositorio : IReceitaRepositorio
    {
        private readonly SistemaReceitasDbContex _dbContext;

        public ReceitaRepositorio(SistemaReceitasDbContex sistemaReceitasDbContex)
        {
            _dbContext = sistemaReceitasDbContex;
        }

        public async Task<List<ReceitaModel>> BuscarTodasReceitas()
        {
            return await _dbContext.receita.ToListAsync();
        }

        public async Task<ReceitaModel> BuscarReceitaPorId(int id)
        {
            return await _dbContext.receita.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<ReceitaModel> CadastrarReceita(ReceitaModel receita)
        {
            await _dbContext.receita.AddAsync(receita);
            await _dbContext.SaveChangesAsync();

            return receita;
        }

        public async Task<ReceitaModel> Atualizar(ReceitaModel receita, int id)
        {
            ReceitaModel receitaPorId = await BuscarReceitaPorId(id);

            if (receitaPorId == null)
            {
                throw new Exception($"Receita para o ID: {id} não foi encontrado no banco de dados");
            }

            receitaPorId.titulo = receita.titulo;
            receitaPorId.descricao = receita.descricao;
            //receitaPorId.imagem = receita.imagem;

            _dbContext.receita.Update(receitaPorId);
            await _dbContext.SaveChangesAsync();

            return receitaPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            ReceitaModel receitaPorId = await BuscarReceitaPorId(id);

            if (receitaPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados");
            }

            _dbContext.receita.Remove(receitaPorId);
            await _dbContext.SaveChangesAsync();
            return true;

        }

    }
}
