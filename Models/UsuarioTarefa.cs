using System;
using System.Collections.Generic;

namespace ContatosMVC_webapi.Models
{
    public partial class UsuarioTarefa
    {
        public UsuarioTarefa() { }

        public UsuarioTarefa(int usuarioId, int tarefaId)
        {
            this.UsuarioId = usuarioId;
            this.TarefaId = tarefaId;
        }

        public int UsuarioId { get; set; }
        public Usuario? usuario { get; set; }
        public int TarefaId { get; set; }
        public Tarefa? tarefa { get; set; }
    }
}
