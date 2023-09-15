using Dapper;
using MiniChefe.Models;

namespace MiniChefe.DataAccess
{
    public class UsuarioService : Dao
    {
        public Usuario Incluir(Usuario usuario)
        {
            try
            {
                AbrirConexao();
                string sql = "INSERT INTO Usuario ( email, nome, senha) VALUES ( @Email, @Nome, @Senha);";
                int registro = Conn.Execute(sql, new
                {
                    usuario.Email,
                    usuario.Nome,
                    usuario.Senha,
                });
                if (registro > 0)
                {
                    Usuario usuario1 = Conn.QueryFirstOrDefault<Usuario>(
                        "SELECT * FROM Usuario WHERE id = " +
                        "(SELECT MAX(id) FROM Usuario)");
                    return usuario1;
                }
                return null;
            }
            finally
            {
                FecharConexao();
            }
        }
        public bool RemoverUsuario(int id)
        {
            try
            {
                AbrirConexao();
                int registros = Conn.Execute("DELETE FROM Usuario WHERE id = @id", new { id });
                return registros > 0;
            }
            finally
            {
                FecharConexao();
            }
        }

    }
}
