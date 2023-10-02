using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Controllers;
using SistemaDeTarefas.Datas;
using SistemaDeTarefas.Repositorios.Interface;

namespace SistemaDeTarefas.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepository
    {
        private readonly SistemadeTarefasDBcontex _dbContext;
        public UsuarioRepositorio(SistemadeTarefasDBcontex sistemadeTarefasDBcontex)
        {
            _dbContext = sistemadeTarefasDBcontex;
        }
        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x=> x.Id == id);
        } 

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {

            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }
        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
           UsuarioModel usuarioPorId = await BuscarPorId(id);
            
            if(usuarioPorId == null)
            {
                throw new NotImplementedException($"Usuario para o ID: {id} não foi encontrado no banco de dados. ");
            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuarioPorId);
            _dbContext.SaveChanges();

            return usuarioPorId;
           
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new NotImplementedException($"Usuario para o ID: {id} não foi encontrado no banco de dados. ");
            }
            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
