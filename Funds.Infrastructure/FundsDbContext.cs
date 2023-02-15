using Funds.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funds.Infrastructure
{
    public partial class FundsDbContext : DbContext
    {
        public FundsDbContext()
        {
        }

        public FundsDbContext(DbContextOptions<FundsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FundsEntity> Funds { get; set; }

        public virtual DbSet<FundsPrices> FundsPrices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Server=DESKTOP-H2BR7E2;Database=FundsDB;Trusted_Connection=True;Integrated Security=True;Encrypt=false;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FundsEntity>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Code)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.Id).HasMaxLength(50);
            });

            modelBuilder.Entity<FundsPrices>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Close)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("_Close");
                entity.Property(e => e.Date).HasColumnType("date");
                entity.Property(e => e.FundId)
                    .HasMaxLength(512)
                    .IsUnicode(false);
                entity.Property(e => e.Id)
                    .HasMaxLength(512)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
