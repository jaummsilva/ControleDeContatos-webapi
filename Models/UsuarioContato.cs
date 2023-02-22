using System;
using System.Collections.Generic;

namespace ContatosMVC_webapi.Models
{
    public partial class UsuarioContato
    {
        public UsuarioContato() { }

        public UsuarioContato(int usuarioId, int contatoId)
        {
            this.UsuarioId = usuarioId;
            this.ContatoId = contatoId;
        }

        public int UsuarioId { get; set; }
        public Usuario? usuario { get; set; }
        public int ContatoId { get; set; }
        public Contato? contato { get; set; }
    }
}
