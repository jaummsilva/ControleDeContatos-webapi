using ContatosMVC_webapi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ContatosMVC_webapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContatosMVC_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly IRepository _repo;

        public TarefaController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllTarefasAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("{TarefaId}")]
        public async Task<IActionResult> GetByTarefaId(int TarefaId)
        {
            try
            {
                var result = await _repo.GetTarefaAsyncById(TarefaId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("ByUsuario/{usuarioId}")]
        public async Task<IActionResult> GetByUsuarioId(int usuarioId)
        {
            try
            {
                var result = await _repo.GetTarefasAsyncByUsuarioId(usuarioId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> post(Tarefa model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpPut("{tarefaId}")]
        public async Task<IActionResult> put(int tarefaId, Tarefa model)
        {
            try
            {
                var tarefa = await _repo.GetTarefaAsyncById(tarefaId);
                if (tarefa == null) return NotFound();

                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpDelete("{usuarioId}")]
        public async Task<IActionResult> delete(int tarefaId)
        {
            try
            {
                var tarefa = await _repo.GetUsuarioAsyncById(tarefaId);
                if (tarefa == null) return NotFound();

                _repo.Delete(tarefa);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok(new { Message = "Deletado" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

    }
}

