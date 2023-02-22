using System;
using System.Collections.Generic;

namespace ContatosMVC_webapi.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Contatos = new HashSet<Contato>();
            Tarefas = new HashSet<Tarefa>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Perfil { get; set; }
        public string Senha { get; set; } = null!;
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public virtual ICollection<Contato> Contatos { get; set; }
        public virtual ICollection<Tarefa> Tarefas { get; set; }

        public IEnumerable<UsuarioTarefa> UsuarioTarefas { get; set; }

        public IEnumerable<UsuarioContato> UsuarioContatos { get; set; }

    }
}
