using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Repositorios.Interface;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepository _usarioRepositorio;
        public UsuarioController(IUsuarioRepository usuarioRepository) {
            _usarioRepositorio = usuarioRepository;
                }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
        {
          List<UsuarioModel> usuarios = await _usarioRepositorio.BuscarTodosUsuarios();
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
        {
            UsuarioModel  usuarios = await _usarioRepositorio.BuscarPorId(id);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
          UsuarioModel usuario =  await _usarioRepositorio.Adicionar(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel, int id)
        {
            usuarioModel.Id = id;
            UsuarioModel usuario = await _usarioRepositorio.Atualizar(usuarioModel, id);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<UsuarioModel>> apagar(int id)
        {
           bool apagado = await _usarioRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }


}
