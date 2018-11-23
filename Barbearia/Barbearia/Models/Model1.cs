namespace Barbearia.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model13")
        {
        }

        public virtual DbSet<AGENDA> AGENDA { get; set; }
        public virtual DbSet<ATENDIMENTO> ATENDIMENTO { get; set; }
        public virtual DbSet<CABELELEIRO> CABELELEIRO { get; set; }
        public virtual DbSet<CLIENTE> CLIENTE { get; set; }
        public virtual DbSet<ESTOQUE> ESTOQUE { get; set; }
        public virtual DbSet<PRODUTO> PRODUTO { get; set; }
        public virtual DbSet<SERVICO> SERVICO { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AGENDA>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<AGENDA>()
                .Property(e => e.NOME)
                .IsUnicode(false);

            modelBuilder.Entity<AGENDA>()
                .Property(e => e.VALOR)
                .HasPrecision(19, 4);

            modelBuilder.Entity<AGENDA>()
                .Property(e => e.COMENTARIO)
                .IsUnicode(false);

            modelBuilder.Entity<AGENDA>()
                .HasMany(e => e.ATENDIMENTO)
                .WithRequired(e => e.AGENDA)
                .HasForeignKey(e => e.ID_AGENDA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ATENDIMENTO>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<ATENDIMENTO>()
                .Property(e => e.CHECKIN)
                .IsUnicode(false);

            modelBuilder.Entity<ATENDIMENTO>()
                .Property(e => e.CHECKOUT)
                .IsUnicode(false);

            modelBuilder.Entity<ATENDIMENTO>()
                .Property(e => e.VALOR)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CABELELEIRO>()
                .Property(e => e.LOGIN)
                .IsUnicode(false);

            modelBuilder.Entity<CABELELEIRO>()
                .Property(e => e.NOME)
                .IsUnicode(false);

            modelBuilder.Entity<CABELELEIRO>()
                .Property(e => e.SENHA)
                .IsUnicode(false);

            modelBuilder.Entity<CABELELEIRO>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<CABELELEIRO>()
                .Property(e => e.CELULAR)
                .IsUnicode(false);

            modelBuilder.Entity<CABELELEIRO>()
                .HasMany(e => e.AGENDA)
                .WithRequired(e => e.CABELELEIRO)
                .HasForeignKey(e => e.ID_CABELELEIRO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.LOGIN)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.NOME)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.SENHA)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.CELULAR)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUTO>()
                .Property(e => e.NOME)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUTO>()
                .Property(e => e.VALOR)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PRODUTO>()
                .Property(e => e.ESPECIFICACAO)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUTO>()
                .HasMany(e => e.AGENDA)
                .WithOptional(e => e.PRODUTO)
                .HasForeignKey(e => e.ID_PRODUTO);

            modelBuilder.Entity<PRODUTO>()
                .HasMany(e => e.ESTOQUE)
                .WithRequired(e => e.PRODUTO)
                .HasForeignKey(e => e.ID_PRODUTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SERVICO>()
                .Property(e => e.NOME)
                .IsUnicode(false);

            modelBuilder.Entity<SERVICO>()
                .Property(e => e.VALOR)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SERVICO>()
                .HasMany(e => e.AGENDA)
                .WithRequired(e => e.SERVICO)
                .HasForeignKey(e => e.ID_SERVICO)
                .WillCascadeOnDelete(false);
        }
    }
}
