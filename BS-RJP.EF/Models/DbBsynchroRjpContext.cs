using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BS_RJP.EF.Models;

public partial class DbBsynchroRjpContext : DbContext
{
    public DbBsynchroRjpContext()
    {
    }

    public DbBsynchroRjpContext(DbContextOptions<DbBsynchroRjpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAccount> TblAccounts { get; set; }

    public virtual DbSet<TblCustomer> TblCustomers { get; set; }

    public virtual DbSet<TblTransaction> TblTransactions { get; set; }

    public virtual DbSet<TblTransactionType> TblTransactionTypes { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
    
    }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=DbBSynchroRJP;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAccount>(entity =>
        {
            entity.HasKey(e => e.AccountId);

            entity.ToTable("TblAccount");

            entity.HasIndex(e => e.CustomerId, "IX_TblAccount");

            entity.HasIndex(e => e.EntryUserId, "IX_TblAccount_1");

            entity.Property(e => e.Balance).HasColumnType("money");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.TblAccounts)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblAccount_TblCustomer");

            entity.HasOne(d => d.EntryUser).WithMany(p => p.TblAccounts)
                .HasForeignKey(d => d.EntryUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblAccount_TblUser");
        });

        modelBuilder.Entity<TblCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId);

            entity.ToTable("TblCustomer");

            entity.HasIndex(e => e.EntryUserId, "IX_TblCustomer");

            entity.HasIndex(e => e.EntryUserId, "IX_TblCustomer_1");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.EntryUser).WithMany(p => p.TblCustomers)
                .HasForeignKey(d => d.EntryUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblCustomer_TblUser");
        });

        modelBuilder.Entity<TblTransaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId);

            entity.ToTable("TblTransaction");

            entity.HasIndex(e => e.AccountId, "IX_TblTransaction");

            entity.HasIndex(e => e.TransactiontypeId, "IX_TblTransaction_1");

            entity.HasIndex(e => e.EntryUserId, "IX_TblTransaction_2");

            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.TblTransactions)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblTransaction_TblAccount");

            entity.HasOne(d => d.EntryUser).WithMany(p => p.TblTransactions)
                .HasForeignKey(d => d.EntryUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblTransaction_TblUser");

            entity.HasOne(d => d.Transactiontype).WithMany(p => p.TblTransactions)
                .HasForeignKey(d => d.TransactiontypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblTransaction_TblTransactionType");
        });

        modelBuilder.Entity<TblTransactionType>(entity =>
        {
            entity.HasKey(e => e.TransactiontypeId);

            entity.ToTable("TblTransactionType");

            entity.HasIndex(e => e.EntryUserId, "IX_TblTransactionType");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Value).IsRequired();

            entity.HasOne(d => d.EntryUser).WithMany(p => p.TblTransactionTypes)
                .HasForeignKey(d => d.EntryUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblTransactionType_TblUser");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("TblUser");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.Password).IsRequired();
            entity.Property(e => e.Username).IsRequired();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
