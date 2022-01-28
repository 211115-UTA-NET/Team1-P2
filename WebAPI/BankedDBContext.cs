using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPI
{
    public partial class BankedDBContext : DbContext
    {
        public BankedDBContext()
        {
        }

        public BankedDBContext(DbContextOptions<BankedDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Expense> Expenses { get; set; } = null!;
        public virtual DbSet<ExpenseOption> ExpenseOptions { get; set; } = null!;
        public virtual DbSet<Income> Incomes { get; set; } = null!;
        public virtual DbSet<IncomeOption> IncomeOptions { get; set; } = null!;
        public virtual DbSet<Loan> Loans { get; set; } = null!;
        public virtual DbSet<Priority> Priorities { get; set; } = null!;
        public virtual DbSet<Saving> Savings { get; set; } = null!;
        public virtual DbSet<UserInfo> UserInfos { get; set; } = null!;
        public virtual DbSet<UserPassword> UserPasswords { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ExpenseAmount)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ExpenseOptionsId).HasColumnName("ExpenseOptionsID");

                entity.Property(e => e.UserPasswordsId).HasColumnName("UserPasswordsID");

                entity.HasOne(d => d.ExpenseOptions)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.ExpenseOptionsId)
                    .HasConstraintName("FK__Expenses__Expens__71D1E811");

                entity.HasOne(d => d.UserPasswords)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.UserPasswordsId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Expenses__UserPa__70DDC3D8");
            });

            modelBuilder.Entity<ExpenseOption>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ExpenseName).HasMaxLength(50);

                entity.Property(e => e.PriorityId).HasColumnName("priorityId");

                entity.HasOne(d => d.Priority)
                    .WithMany(p => p.ExpenseOptions)
                    .HasForeignKey(d => d.PriorityId)
                    .HasConstraintName("FK__ExpenseOp__prior__6E01572D");
            });

            modelBuilder.Entity<Income>(entity =>
            {
                entity.ToTable("Income");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IncomeAmount)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IncomeOptionsId).HasColumnName("IncomeOptionsID");

                entity.Property(e => e.UserPasswordsId).HasColumnName("UserPasswordsID");

                entity.HasOne(d => d.IncomeOptions)
                    .WithMany(p => p.Incomes)
                    .HasForeignKey(d => d.IncomeOptionsId)
                    .HasConstraintName("FK__Income__IncomeOp__6A30C649");

                entity.HasOne(d => d.UserPasswords)
                    .WithMany(p => p.Incomes)
                    .HasForeignKey(d => d.UserPasswordsId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Income__UserPass__693CA210");
            });

            modelBuilder.Entity<IncomeOption>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IncomeName).HasMaxLength(50);

                entity.Property(e => e.PriorityId).HasColumnName("priorityId");

                entity.HasOne(d => d.Priority)
                    .WithMany(p => p.IncomeOptions)
                    .HasForeignKey(d => d.PriorityId)
                    .HasConstraintName("FK__IncomeOpt__prior__66603565");
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LoanAmount)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LoanName).HasMaxLength(100);

                entity.Property(e => e.MonthlyPayments)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UserPasswordsId).HasColumnName("UserPasswordsID");

                entity.HasOne(d => d.UserPasswords)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.UserPasswordsId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Loans__UserPassw__7A672E12");
            });

            modelBuilder.Entity<Priority>(entity =>
            {
                entity.HasIndex(e => e.PriorityName, "UQ__Prioriti__8E40AF0B7DCF562B")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PriorityName)
                    .HasMaxLength(50)
                    .HasColumnName("priorityName");
            });

            modelBuilder.Entity<Saving>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SavingsAddedMonthly)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SavingsAmount)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SavingsName).HasMaxLength(100);

                entity.Property(e => e.UserPasswordsId).HasColumnName("UserPasswordsID");

                entity.HasOne(d => d.UserPasswords)
                    .WithMany(p => p.Savings)
                    .HasForeignKey(d => d.UserPasswordsId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Savings__UserPas__75A278F5");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserPasswordsId)
                    .HasName("PK__UserInfo__A69961879072E782");

                entity.ToTable("UserInfo");

                entity.Property(e => e.UserPasswordsId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserPasswordsID");

                entity.Property(e => e.SavingsGoal)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.UserPasswords)
                    .WithOne(p => p.UserInfo)
                    .HasForeignKey<UserInfo>(d => d.UserPasswordsId)
                    .HasConstraintName("FK__UserInfo__UserPa__5FB337D6");
            });

            modelBuilder.Entity<UserPassword>(entity =>
            {
                entity.HasIndex(e => e.UserName, "UQ__UserPass__C9F28456A2159EBA")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.Property(e => e.UserPassword1)
                    .HasMaxLength(50)
                    .HasColumnName("UserPassword");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
