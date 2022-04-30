using Domain;
using Microsoft.EntityFrameworkCore;

namespace TrabalhoPIMVII.DataLayer
{
    public class Context : DbContext
    {
        
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS01;Database=master;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region PessoaTelefone
            modelBuilder.Entity<PessoaTelefone>().ToTable("PESSOA_TELEFONE");
            modelBuilder.Entity<PessoaTelefone>().HasKey(pt => new { pt.PessoaId, pt.TelefoneId });

            modelBuilder.Entity<PessoaTelefone>()
                .HasOne(sc => sc.Pessoa)
                .WithMany(s => s.PessoaTelefone)
                .HasForeignKey(sc => sc.PessoaId);


            modelBuilder.Entity<PessoaTelefone>()
                .HasOne(sc => sc.Telefone)
                .WithMany(s => s.PessoaTelefone)
                .HasForeignKey(sc => sc.TelefoneId);
                
            #endregion

            #region Telefone

            modelBuilder.Entity<Telefone>()
                .ToTable("TELEFONE");

            modelBuilder.Entity<Telefone>()
                .HasKey(t => t.TelefoneId);


            modelBuilder.Entity<Telefone>()
                .Property(t => t.TelefoneId)
                .HasColumnName("ID")
                .UseIdentityColumn();

            modelBuilder.Entity<Telefone>()
                .Property(t => t.Numero)
                .HasColumnName("NUMERO");

            modelBuilder.Entity<Telefone>()
                .Property(t => t.DDD)
                .HasColumnName("DDD");

            modelBuilder.Entity<Telefone>()
                .HasOne(t => t.Tipo)
                .WithOne();

            modelBuilder.Entity<Telefone>()
               .Property(t => t.TipoId)
               .HasColumnName("TIPO");
            #endregion

            #region TipoTelefone

            modelBuilder.Entity<TipoTelefone>()
                .ToTable("TELEFONE_TIPO");

            modelBuilder.Entity<TipoTelefone>(endereco => {
                endereco.HasKey(t => t.TipoTelefoneId);
                endereco.Property(t => t.TipoTelefoneId).HasColumnName("ID").UseIdentityColumn();
            });

            modelBuilder.Entity<TipoTelefone>()
                .Property(tt => tt.Tipo)
                .HasMaxLength(10)
                .HasColumnType("varchar")
                .IsRequired()
                .HasColumnName("TIPO");

            #endregion

            #region Pessoa

            modelBuilder.Entity<Pessoa>().ToTable("PESSOA");

            modelBuilder.Entity<Pessoa>(pessoa => {
                pessoa.HasKey(p => p.PessoaId);
                pessoa.Property(p => p.PessoaId).UseIdentityColumn();
            });

            modelBuilder.Entity<Pessoa>()
                .HasOne(p => p.Endereco)
                .WithOne();

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.PessoaId)
                .HasColumnName("ID");

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(256)
                .HasColumnOrder(2);

            modelBuilder.Entity<Pessoa>()
                .Property(p => p.CPF)
                .HasColumnName("CPF")
                .HasColumnType("BIGINT");

            modelBuilder.Entity<Pessoa>()
                .HasIndex(p => p.CPF)
                .IsUnique();

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.EnderecoId)
                .HasColumnName("ENDERECO");
            #endregion

            #region Endereco

            modelBuilder.Entity<Endereco>().ToTable("ENDERECO");

            modelBuilder.Entity<Endereco>(endereco => {
                endereco.HasKey(p => p.EnderecoId);
                endereco.Property(p => p.EnderecoId).UseIdentityColumn();
                endereco.Property(e => e.EnderecoId).HasColumnName("ID");
            });
                

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Logradouro)
                .HasColumnType("varchar")
                .HasMaxLength(256)
                .HasColumnName("LOGRADOURO");

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Bairro)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .HasColumnName("BAIRRO");
            
            modelBuilder.Entity<Endereco>()
                .Property(e => e.Cidade)
                .HasColumnType("varchar")
                .HasMaxLength(30)
                .HasColumnName("CIDADE");

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Estado)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .HasColumnName("ESTADO");

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Numero)
                .HasColumnName("NUMERO");

            modelBuilder.Entity<Endereco>()
                .Property(e => e.CEP)
                .HasColumnName("CEP");

            #endregion
        }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Endereco> Enderecoes { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<TipoTelefone> TipoTelefone { get; set; }
        public DbSet<PessoaTelefone> PessoaTelefone { get; set; }
    }
}
