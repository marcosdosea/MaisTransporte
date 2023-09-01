using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Core;

public partial class MaisTransporteContext : DbContext
{
    public MaisTransporteContext()
    {
    }

    public MaisTransporteContext(DbContextOptions<MaisTransporteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Avaliacao> Avaliacaos { get; set; }

    public virtual DbSet<Motoristum> Motorista { get; set; }

    public virtual DbSet<Passageiro> Passageiros { get; set; }

    public virtual DbSet<Reembolso> Reembolsos { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Sugestaoviagem> Sugestaoviagems { get; set; }

    public virtual DbSet<Veiculo> Veiculos { get; set; }

    public virtual DbSet<Viagem> Viagems { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=123456;database=ModeloMaisTransporte");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Avaliacao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("avaliacao");

            entity.HasIndex(e => e.IdPassageiro, "fk_Avaliacao_Passageiro1_idx");

            entity.HasIndex(e => e.IdViagem, "fk_Avaliacao_Viagem1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Comentario)
                .HasMaxLength(200)
                .HasColumnName("comentario");
            entity.Property(e => e.IdPassageiro)
                .HasColumnType("int(11)")
                .HasColumnName("idPassageiro");
            entity.Property(e => e.IdViagem)
                .HasColumnType("int(11)")
                .HasColumnName("idViagem");
            entity.Property(e => e.Nota)
                .HasColumnType("int(11)")
                .HasColumnName("nota");

            entity.HasOne(d => d.IdPassageiroNavigation).WithMany(p => p.Avaliacaos)
                .HasForeignKey(d => d.IdPassageiro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Avaliacao_Passageiro1");

            entity.HasOne(d => d.IdViagemNavigation).WithMany(p => p.Avaliacaos)
                .HasForeignKey(d => d.IdViagem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Avaliacao_Viagem1");
        });

        modelBuilder.Entity<Motoristum>(entity =>
        {
            entity.HasKey(e => e.IdPassageiro).HasName("PRIMARY");

            entity.ToTable("motorista");

            entity.HasIndex(e => e.IdPassageiro, "fk_Motorista_Passageiro1_idx");

            entity.Property(e => e.IdPassageiro)
                .HasColumnType("int(11)")
                .HasColumnName("idPassageiro");
            entity.Property(e => e.DataEmissao)
                .HasColumnType("datetime")
                .HasColumnName("dataEmissao");
            entity.Property(e => e.DataValidacao)
                .HasColumnType("datetime")
                .HasColumnName("dataValidacao");
            entity.Property(e => e.Estado)
                .HasMaxLength(2)
                .HasColumnName("estado");
            entity.Property(e => e.Expeditor)
                .HasMaxLength(5)
                .HasColumnName("expeditor");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(15)
                .HasColumnName("numeroDocumento");
            entity.Property(e => e.Status)
                .HasColumnType("enum('Solicitado','Ativo','Inativo')")
                .HasColumnName("status");

            entity.HasOne(d => d.IdPassageiroNavigation).WithOne(p => p.Motoristum)
                .HasForeignKey<Motoristum>(d => d.IdPassageiro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Motorista_Passageiro1");
        });

        modelBuilder.Entity<Passageiro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("passageiro");

            entity.HasIndex(e => e.Cpf, "cpf_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Cpf, "idx_cpf");

            entity.HasIndex(e => e.Nome, "idx_nome");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Cpf)
                .HasMaxLength(15)
                .HasColumnName("cpf");
            entity.Property(e => e.DataNascimento)
                .HasColumnType("datetime")
                .HasColumnName("dataNascimento");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
            entity.Property(e => e.Telefone)
                .HasMaxLength(15)
                .HasColumnName("telefone");

            entity.HasMany(d => d.IdSugestaoViagems).WithMany(p => p.IdPassageiros)
                .UsingEntity<Dictionary<string, object>>(
                    "Passageirosugestaoviagem",
                    r => r.HasOne<Sugestaoviagem>().WithMany()
                        .HasForeignKey("IdSugestaoViagem")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_PassageiroSugestaoViagem_SugestaoViagem1"),
                    l => l.HasOne<Passageiro>().WithMany()
                        .HasForeignKey("IdPassageiro")
                        .HasConstraintName("fk_PassageiroSugestaoViagem_Passageiro1"),
                    j =>
                    {
                        j.HasKey("IdPassageiro", "IdSugestaoViagem").HasName("PRIMARY");
                        j.ToTable("passageirosugestaoviagem");
                        j.HasIndex(new[] { "IdPassageiro" }, "fk_Passageiro_has_SugestaoViagem_Passageiro1_idx");
                        j.HasIndex(new[] { "IdSugestaoViagem" }, "fk_Passageiro_has_SugestaoViagem_SugestaoViagem1_idx");
                        j.IndexerProperty<int>("IdPassageiro")
                            .ValueGeneratedOnAdd()
                            .HasColumnType("int(11)")
                            .HasColumnName("idPassageiro");
                        j.IndexerProperty<int>("IdSugestaoViagem")
                            .HasColumnType("int(11)")
                            .HasColumnName("idSugestaoViagem");
                    });

            entity.HasMany(d => d.IdViagems).WithMany(p => p.IdPassageiros)
                .UsingEntity<Dictionary<string, object>>(
                    "Passageiroviagem",
                    r => r.HasOne<Viagem>().WithMany()
                        .HasForeignKey("IdViagem")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_PassageiroViagem_Viagem1"),
                    l => l.HasOne<Passageiro>().WithMany()
                        .HasForeignKey("IdPassageiro")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_PassageiroViagem_Passageiro1"),
                    j =>
                    {
                        j.HasKey("IdPassageiro", "IdViagem").HasName("PRIMARY");
                        j.ToTable("passageiroviagem");
                        j.HasIndex(new[] { "IdPassageiro" }, "fk_Passageiro_has_Viagem_Passageiro1_idx");
                        j.HasIndex(new[] { "IdViagem" }, "fk_Passageiro_has_Viagem_Viagem1_idx");
                        j.IndexerProperty<int>("IdPassageiro")
                            .HasColumnType("int(11)")
                            .HasColumnName("idPassageiro");
                        j.IndexerProperty<int>("IdViagem")
                            .HasColumnType("int(11)")
                            .HasColumnName("idViagem");
                    });
        });

        modelBuilder.Entity<Reembolso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("reembolso");

            entity.HasIndex(e => e.IdPassageiro, "fk_Reembolso_Passageiro1_idx");

            entity.HasIndex(e => e.IdViagem, "fk_Reembolso_Viagem1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Data)
                .HasColumnType("datetime")
                .HasColumnName("data");
            entity.Property(e => e.IdPassageiro)
                .HasColumnType("int(11)")
                .HasColumnName("idPassageiro");
            entity.Property(e => e.IdViagem)
                .HasColumnType("int(11)")
                .HasColumnName("idViagem");
            entity.Property(e => e.Valor).HasColumnName("valor");

            entity.HasOne(d => d.IdPassageiroNavigation).WithMany(p => p.Reembolsos)
                .HasForeignKey(d => d.IdPassageiro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Reembolso_Passageiro1");

            entity.HasOne(d => d.IdViagemNavigation).WithMany(p => p.Reembolsos)
                .HasForeignKey(d => d.IdViagem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Reembolso_Viagem1");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("reserva");

            entity.HasIndex(e => e.IdPassageiro, "fk_Reserva_Passageiro1_idx");

            entity.HasIndex(e => e.IdViagem, "fk_Reserva_Viagem1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DataCompra)
                .HasColumnType("datetime")
                .HasColumnName("dataCompra");
            entity.Property(e => e.IdPassageiro)
                .HasColumnType("int(11)")
                .HasColumnName("idPassageiro");
            entity.Property(e => e.IdViagem)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(11)")
                .HasColumnName("idViagem");
            entity.Property(e => e.StausPagamento)
                .HasMaxLength(50)
                .HasColumnName("stausPagamento");
            entity.Property(e => e.ValorPagamento).HasColumnName("valorPagamento");

            entity.HasOne(d => d.IdPassageiroNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdPassageiro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Reserva_Passageiro1");

            entity.HasOne(d => d.IdViagemNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdViagem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Reserva_Viagem1");
        });

        modelBuilder.Entity<Sugestaoviagem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("sugestaoviagem");

            entity.HasIndex(e => e.IdPassageiro, "fk_SugestaoViagem_Passageiro1_idx");

            entity.HasIndex(e => e.LocalDestino, "idx_localDestino");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DataChegada)
                .HasColumnType("datetime")
                .HasColumnName("dataChegada");
            entity.Property(e => e.DataPartida)
                .HasColumnType("datetime")
                .HasColumnName("dataPartida");
            entity.Property(e => e.Descricao)
                .HasMaxLength(100)
                .HasColumnName("descricao");
            entity.Property(e => e.IdPassageiro)
                .HasColumnType("int(11)")
                .HasColumnName("idPassageiro");
            entity.Property(e => e.LocalDestino)
                .HasMaxLength(50)
                .HasColumnName("localDestino");
            entity.Property(e => e.LocalOrigem)
                .HasMaxLength(50)
                .HasColumnName("localOrigem");
            entity.Property(e => e.Status)
                .HasColumnType("enum('Disponível','Confirmada','Concluída','Cancelada')")
                .HasColumnName("status");
            entity.Property(e => e.Titulo)
                .HasMaxLength(50)
                .HasColumnName("titulo");
            entity.Property(e => e.TotalVagas)
                .HasColumnType("int(11)")
                .HasColumnName("totalVagas");
            entity.Property(e => e.ValorPassagem).HasColumnName("valorPassagem");

            entity.HasOne(d => d.IdPassageiroNavigation).WithMany(p => p.Sugestaoviagems)
                .HasForeignKey(d => d.IdPassageiro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_SugestaoViagem_Passageiro1");
        });

        modelBuilder.Entity<Veiculo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("veiculo");

            entity.HasIndex(e => e.IdMotoristaPassageiro, "fk_Veiculo_Motorista1_idx");

            entity.HasIndex(e => e.Placa, "idx_placa");

            entity.HasIndex(e => e.Renavam, "renavam_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DataEmissao)
                .HasColumnType("datetime")
                .HasColumnName("dataEmissao");
            entity.Property(e => e.Estado)
                .HasMaxLength(2)
                .HasColumnName("estado");
            entity.Property(e => e.Expeditor)
                .HasMaxLength(5)
                .HasColumnName("expeditor");
            entity.Property(e => e.IdMotoristaPassageiro)
                .HasColumnType("int(11)")
                .HasColumnName("idMotoristaPassageiro");
            entity.Property(e => e.Placa)
                .HasMaxLength(10)
                .HasColumnName("placa");
            entity.Property(e => e.Renavam)
                .HasMaxLength(15)
                .HasColumnName("renavam");

            entity.HasOne(d => d.IdMotoristaPassageiroNavigation).WithMany(p => p.Veiculos)
                .HasForeignKey(d => d.IdMotoristaPassageiro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Veiculo_Motorista1");
        });

        modelBuilder.Entity<Viagem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("viagem");

            entity.HasIndex(e => e.LocalDestino, "idx_localDestino");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DataChegada)
                .HasColumnType("datetime")
                .HasColumnName("dataChegada");
            entity.Property(e => e.DataPartida)
                .HasColumnType("datetime")
                .HasColumnName("dataPartida");
            entity.Property(e => e.Descricao)
                .HasMaxLength(100)
                .HasColumnName("descricao");
            entity.Property(e => e.IdMotorista)
                .HasColumnType("int(11)")
                .HasColumnName("idMotorista");
            entity.Property(e => e.LocalDestino)
                .HasMaxLength(50)
                .HasColumnName("localDestino");
            entity.Property(e => e.LocalOrigem)
                .HasMaxLength(50)
                .HasColumnName("localOrigem");
            entity.Property(e => e.Titulo)
                .HasMaxLength(50)
                .HasColumnName("titulo");
            entity.Property(e => e.TotalVagas)
                .HasColumnType("int(11)")
                .HasColumnName("totalVagas");
            entity.Property(e => e.ValorPassagem).HasColumnName("valorPassagem");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
