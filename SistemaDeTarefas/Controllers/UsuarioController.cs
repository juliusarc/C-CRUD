using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Repositorios.Interface;
using Swashbuckle.AspNetCore.Annotations;

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
        [ProducesResponseType(typeof(IEnumerable<UsuarioModel>), StatusCodes.Status200OK)]
        [SwaggerOperation(summary: "Busca todos os Usuarios")]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
        {
            List<UsuarioModel> usuarios = await _usarioRepositorio.BuscarTodosUsuarios();
            return Ok();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<UsuarioModel>), StatusCodes.Status200OK)]
        [SwaggerOperation(summary: "Busca o usuario por Id")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
        {
            UsuarioModel  usuarios = await _usarioRepositorio.BuscarPorId(id);
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<UsuarioModel>), StatusCodes.Status200OK)]
        [SwaggerOperation(summary: "Cadastra o Usuario")]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
          UsuarioModel usuario =  await _usarioRepositorio.Adicionar(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IEnumerable<UsuarioModel>), StatusCodes.Status200OK)]
        [SwaggerOperation(summary: "Alterar os dados do Usuario com o ID passado")]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel, int id)
        {
            usuarioModel.Id = id;
            UsuarioModel usuario = await _usarioRepositorio.Atualizar(usuarioModel, id);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IEnumerable<UsuarioModel>), StatusCodes.Status200OK)]
        [SwaggerOperation(summary: "Apaga os dados do Usuario")]
        public async Task<ActionResult<UsuarioModel>> apagar(int id)
        {
           bool apagado = await _usarioRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }


}
