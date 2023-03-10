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
    public class ContatoController : ControllerBase
    {
        private readonly IRepository _repo;

        public ContatoController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllContatosAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("{ContatoId}")]
        public async Task<IActionResult> GetByContatoId(int ContatoId)
        {
            try
            {
                var result = await _repo.GetTarefaAsyncById(ContatoId);

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
                var result = await _repo.GetContatosAsyncByUsuarioId(usuarioId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> post(Contato model)
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

        [HttpPut("{contatoId}")]
        public async Task<IActionResult> put(int contatoId, Contato model)
        {
            try
            {
                var contato = await _repo.GetContatoAsyncById(contatoId);
                if (contato == null) return NotFound();

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
        public async Task<IActionResult> delete(int contatoId)
        {
            try
            {
                var contato = await _repo.GetUsuarioAsyncById(contatoId);
                if (contato == null) return NotFound();

                _repo.Delete(contato);

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

