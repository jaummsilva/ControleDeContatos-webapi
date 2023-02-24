using ContatosMVC_webapi.Data;
using ContatosMVC_webapi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool_WebAPI.Data
{
    public class Repository : IRepository
    {
        private readonly dbContext _context;

        public Repository(dbContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Usuario[]> GetAllUsuariosAsync()
        {
            IQueryable<Usuario> query = _context.Usuarios;

            query = query.AsNoTracking()
                         .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Usuario> GetUsuarioAsyncById(int usuarioId)
        {
            IQueryable<Usuario>? query = _context.Usuarios;


            query = query.AsNoTracking()
                         .OrderBy(usuario => usuario.Id)
                         .Where(usuario => usuario.Id == usuarioId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Tarefa[]> GetTarefasAsyncByUsuarioId(int usuarioId)
        {
            IQueryable<Tarefa> query = _context.Tarefas;

            query = query.AsNoTracking()
                         .OrderBy(tarefa => tarefa.Id)
                         .Where(tarefa=> tarefa.UsuarioId == usuarioId);

            return await query.ToArrayAsync();
        }

        public async Task<Tarefa[]> GetAllTarefasAsync()
        {
            IQueryable<Tarefa> query = _context.Tarefas;


            query = query.AsNoTracking()
                         .OrderBy(tarefa => tarefa.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Tarefa> GetTarefaAsyncById(int tarefaId)
        {
            IQueryable<Tarefa> query = _context.Tarefas;

            query = query.AsNoTracking()
                         .OrderBy(tarefa => tarefa.Id)
                         .Where(tarefa => tarefa.Id == tarefaId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Contato[]> GetAllContatosAsync()
        {
            IQueryable<Contato> query = _context.Contatos;

            query = query.AsNoTracking()
                         .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Contato> GetContatoAsyncById(int contatoId)
        {
            IQueryable<Contato> query = _context.Contatos;

            query = query.AsNoTracking()
                         .OrderBy(contato => contato.Id)
                         .Where(contato => contato.Id == contatoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Contato[]> GetContatosAsyncByUsuarioId(int usuarioId)
        {
            IQueryable<Contato> query = _context.Contatos;

            query = query.AsNoTracking()
                         .OrderBy(contato => contato.Id)
                         .Where(contato=> contato.UsuarioId == usuarioId);

            return await query.ToArrayAsync();
        }
    }
}
