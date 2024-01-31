using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositories.Interfaces;

namespace SistemaDeTarefas.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TarefaController : ControllerBase
	{
		private readonly ITarefaRepository _tarefaRepository;

		public TarefaController(ITarefaRepository tarefaRepository)
		{
			_tarefaRepository = tarefaRepository;
		}

		[HttpGet]
		public async Task<ActionResult<List<TarefaModel>>> BuscarTodasTarefas()
		{
			List<TarefaModel> usuarios = await _tarefaRepository.BuscarTodasTarefas();
			return Ok(usuarios);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<TarefaModel>> BuscarPorId(int id)
		{
			TarefaModel usuario = await _tarefaRepository.BuscarPorId(id);
			return Ok(usuario);
		}

		[HttpPost]
		public async Task<ActionResult<TarefaModel>> Cadastrar([FromBody] TarefaModel tarefaModel)
		{
			TarefaModel usuario = await _tarefaRepository.Adicionar(tarefaModel);
			return Ok(usuario);
		}

		[HttpPut]
		public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] TarefaModel tarefaModel, int id)
		{
			tarefaModel.Id = id;
			TarefaModel tarefa = await _tarefaRepository.Atualizar(tarefaModel, id);
			return Ok(tarefa);
		}

		[HttpDelete]
		public async Task<ActionResult<TarefaModel>> Apagar(int id)
		{
			bool apagado = await _tarefaRepository.Apagar(id);
			return Ok(apagado);
		}
	}
}
