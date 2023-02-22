using System;
using System.Collections.Generic;

namespace ContatosMVC_webapi.Models
{
    public partial class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Celular { get; set; } = null!;
        public int? UsuarioId { get; set; }

        public virtual Usuario? Usuario { get; set; }

        public IEnumerable<UsuarioContato> UsuarioContatos { get; set; }

    }
}
