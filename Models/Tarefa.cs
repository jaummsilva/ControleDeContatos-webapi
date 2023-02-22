using System;
using System.Collections.Generic;

namespace ContatosMVC_webapi.Models
{
    public partial class Tarefa
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = null!;
        public DateTime DataFinal { get; set; }
        public int? TarefaEnum { get; set; }
        public int? UsuarioId { get; set; }

        public virtual Usuario? Usuario { get; set; }

        public IEnumerable<UsuarioTarefa> UsuarioTarefas { get; set; }
    }
}
