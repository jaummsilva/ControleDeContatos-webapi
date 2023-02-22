using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ContatosMVC_webapi.Models
{
    public partial class dbContext : DbContext
    {
        public dbContext()
        {
        }

        public dbContext(DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contato> Contatos { get; set; } = null!;
        public virtual DbSet<Tarefa> Tarefas { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-PC02EDM;Database=Db_SistemaContatos;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contato>(entity =>
            {
                entity.HasIndex(e => e.UsuarioId, "IX_Contatos_UsuarioId");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Contatos)
                    .HasForeignKey(d => d.UsuarioId);
            });

            modelBuilder.Entity<Tarefa>(entity =>
            {
                entity.HasIndex(e => e.UsuarioId, "IX_Tarefas_UsuarioId");

                entity.Property(e => e.Descricao).HasColumnName("descricao");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Tarefas)
                    .HasForeignKey(d => d.UsuarioId);
            });

            modelBuilder.Entity<UsuarioTarefa>(entity =>
            {
                entity.HasKey(AD => new { AD.UsuarioId, AD.TarefaId });
            });
            modelBuilder.Entity<UsuarioContato>(entity =>
            {
                entity.HasKey(AD => new { AD.UsuarioId, AD.ContatoId });
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
