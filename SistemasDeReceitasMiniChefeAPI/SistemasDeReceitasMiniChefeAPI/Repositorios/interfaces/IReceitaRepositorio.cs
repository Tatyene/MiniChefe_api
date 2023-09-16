using SistemasDeReceitasMiniChefeAPI.Models;

namespace SistemasDeReceitasMiniChefeAPI.Repositorios.interfaces
{
    public interface IReceitaRepositorio
    {
        Task<List<ReceitaModel>> BuscarTodasReceitas();

        Task<ReceitaModel> BuscarReceitaPorId(int id);

        Task<ReceitaModel> CadastrarReceita(ReceitaModel receita);

        Task<ReceitaModel> Atualizar(ReceitaModel receita, int id);

        Task<bool> Apagar(int id);
    }
}
