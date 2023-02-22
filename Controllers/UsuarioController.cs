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
    public class UsuarioController : ControllerBase
    {
        private readonly IRepository _repo;

        public UsuarioController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllUsuariosAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("{UsuarioId}")]
        public async Task<IActionResult> GetByUsuarioId(int UsuarioId)
        {
            try
            {
                var result = await _repo.GetUsuarioAsyncById(UsuarioId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> post(Usuario model)
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

        [HttpPut("{usuarioId}")]
        public async Task<IActionResult> put(int usuarioId, Usuario model)
        {
            try
            {
                var usuario = await _repo.GetUsuarioAsyncById(usuarioId);
                if (usuario == null) return NotFound();

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
        public async Task<IActionResult> delete(int usuarioId)
        {
            try
            {
                var usuario = await _repo.GetUsuarioAsyncById(usuarioId);
                if (usuario == null) return NotFound();

                _repo.Delete(usuario);

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

