using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IP_Booking_Overtime
{
    public partial class IndividualProject_DatabaseContext : DbContext
    {
        public IndividualProject_DatabaseContext()
        {
        }

        public IndividualProject_DatabaseContext(DbContextOptions<IndividualProject_DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Overtime> Overtime { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=IndividualProject_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Overtime>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Day).HasMaxLength(40);

                entity.Property(e => e.DtStartDdmmmyyyy)
                    .HasColumnName("dtStart_ddmmmyyyy")
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(replace(CONVERT([varchar](20),[Start time],(100)),'',''))");

                entity.Property(e => e.NumberOfHours).HasColumnName("Number of hours");

                entity.Property(e => e.StartTime).HasColumnName("Start time");

                entity.Property(e => e.UserId).HasColumnName("User ID");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_OvertimeUsers");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__1788CCAC31E05592");

                entity.Property(e => e.UserId).HasColumnName("User ID");

                entity.Property(e => e.UserName).HasMaxLength(40);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
