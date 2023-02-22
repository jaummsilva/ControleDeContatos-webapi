using ContatosMVC_webapi.Models;
using System.Threading.Tasks;

namespace ContatosMVC_webapi.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //USUARIO
        Task<Usuario[]> GetAllUsuariosAsync();
        Task<Usuario> GetUsuarioAsyncById(int usuarioId);

        //TAREFA
        Task<Tarefa[]> GetAllTarefasAsync();
        Task<Tarefa> GetTarefaAsyncById(int tarefaId);
        Task<Tarefa[]> GetTarefasAsyncByUsuarioId(int usuarioId);

        //Contato 

        Task<Contato[]> GetAllContatosAsync();
        Task<Contato> GetContatoAsyncById(int contatoId);
        Task<Contato[]> GetContatosAsyncByUsuarioId(int usuarioId);
    }
}
