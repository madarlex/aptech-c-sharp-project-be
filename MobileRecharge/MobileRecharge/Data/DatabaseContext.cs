using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MobileRecharge.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<AccountType> AccountTypes { get; set; } = null!;
        public virtual DbSet<EmailConfiguration> EmailConfigurations { get; set; } = null!;
        public virtual DbSet<EmailRegistration> EmailRegistrations { get; set; } = null!;
        public virtual DbSet<EmailSignUp> EmailSignUps { get; set; } = null!;
        public virtual DbSet<EmailTemplate> EmailTemplates { get; set; } = null!;
        public virtual DbSet<FeedBack> FeedBacks { get; set; } = null!;
        public virtual DbSet<PostPaid> PostPaids { get; set; } = null!;
        public virtual DbSet<PostPaidHistory> PostPaidHistories { get; set; } = null!;
        public virtual DbSet<Recharge> Recharges { get; set; } = null!;
        public virtual DbSet<RechargeHistory> RechargeHistories { get; set; } = null!;
        public virtual DbSet<RechargeType> RechargeTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=VN-PF3DTCEV;Database= RechargeMobile;user id=sa;password=1234567");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasColumnType("text");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IdentityCard)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Service)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.AccountType)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.AccountTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_AccountType");
            });

            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.ToTable("AccountType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmailConfiguration>(entity =>
            {
                entity.ToTable("EmailConfiguration");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password).HasMaxLength(100);
            });

            modelBuilder.Entity<EmailRegistration>(entity =>
            {
                entity.ToTable("EmailRegistration");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmailSignUp>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.ToTable("EmailSignUp");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Otp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("OTP");
            });

            modelBuilder.Entity<EmailTemplate>(entity =>
            {
                entity.ToTable("EmailTemplate");

                entity.Property(e => e.Bcc)
                    .HasMaxLength(255)
                    .HasColumnName("BCC");

                entity.Property(e => e.Cc)
                    .HasMaxLength(255)
                    .HasColumnName("CC");

                entity.Property(e => e.KeyGuide).HasMaxLength(500);

                entity.Property(e => e.Subject).HasMaxLength(500);

                entity.Property(e => e.Type).HasMaxLength(100);
            });

            modelBuilder.Entity<FeedBack>(entity =>
            {
                entity.ToTable("FeedBack");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(30);
            });

            modelBuilder.Entity<PostPaid>(entity =>
            {
                entity.ToTable("Post Paid");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PostPaidHistory>(entity =>
            {
                entity.ToTable("Post Paid History");

                entity.Property(e => e.Code)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.PostPaidHistories)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Post Paid History_Account");

                entity.HasOne(d => d.PostPaid)
                    .WithMany(p => p.PostPaidHistories)
                    .HasForeignKey(d => d.PostPaidId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Post Paid History_Post Paid");
            });

            modelBuilder.Entity<Recharge>(entity =>
            {
                entity.ToTable("Recharge");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.RechargeType)
                    .WithMany(p => p.Recharges)
                    .HasForeignKey(d => d.RechargeTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recharge_Recharge Type");
            });

            modelBuilder.Entity<RechargeHistory>(entity =>
            {
                entity.ToTable("Recharge History");

                entity.Property(e => e.Code)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.RechargeHistories)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recharge History_Account");

                entity.HasOne(d => d.Recharge)
                    .WithMany(p => p.RechargeHistories)
                    .HasForeignKey(d => d.RechargeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recharge History_Recharge2");
            });

            modelBuilder.Entity<RechargeType>(entity =>
            {
                entity.ToTable("Recharge Type");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
