using Microsoft.EntityFrameworkCore;
using SistemasDeReceitasMiniChefeAPI.Data;
using SistemasDeReceitasMiniChefeAPI.Models;
using SistemasDeReceitasMiniChefeAPI.Repositorios.interfaces;

namespace SistemasDeReceitasMiniChefeAPI.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaReceitasDbContex _dbContext;

        public UsuarioRepositorio(SistemaReceitasDbContex sistemaReceitasDbContex)
        {
            _dbContext = sistemaReceitasDbContex;
        }


        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.usuario.ToListAsync();
        }


        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.usuario.FirstOrDefaultAsync(X => X.id == id);
        }

       

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
           await _dbContext.usuario.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario; 
        }


        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if(usuarioPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados");
            }

            usuarioPorId.nome = usuario.nome;
            usuarioPorId.email = usuario.email;

            _dbContext.usuario.Update(usuarioPorId);
           await _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados");
            }

            _dbContext.usuario.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;    

        }

    }
}
