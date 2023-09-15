using Dapper;
using MiniChefe.Models;

namespace MiniChefe.DataAccess
{
    public class ReceitaService : Dao
    {
        public IEnumerable<Receita> ListarTodas()
        {
            try
            {
                AbrirConexao();
                return Conn.Query<Receita>("SELECT * FROM Receita;");
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}
