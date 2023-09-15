using Npgsql;

namespace MiniChefe.DataAccess
{
    public class Dao
    {
        private string Conexao
            => "Server=dpg-cjplo70jbais73a7uu5g-a.oregon-postgres.render.com;Database=mini_chefe_db;Port=5432;User Id=mini_chefe_db_user;Password=f8F4HC7mJxv6vh6fyKWQJpdxFbN5UGGJ;";

        protected NpgsqlConnection Conn { get; set; }

        public Dao()
        {
            Conn = new NpgsqlConnection(Conexao);
        }
        protected void AbrirConexao()
        {
            Conn.Open();
        }
        protected void FecharConexao()
        {
            Conn.Close();
        }
    }
}
