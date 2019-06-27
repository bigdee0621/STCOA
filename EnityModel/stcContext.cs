using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace STCOA.EnityModel
{
    public partial class stcContext : DbContext
    {
        public stcContext()
        {
        }

        public stcContext(DbContextOptions<stcContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MailModel> MailModel { get; set; }
        public virtual DbSet<MailType> MailType { get; set; }
        public virtual DbSet<SysDepartment> SysDepartment { get; set; }
        public virtual DbSet<SysPosition> SysPosition { get; set; }
        public virtual DbSet<SysUserinfo> SysUserinfo { get; set; }
        public virtual DbSet<UserMail> UserMail { get; set; }
        public virtual DbSet<UserVocation> UserVocation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=127.0.0.1;User Id=root;Password=;Database=stc");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MailModel>(entity =>
            {
                entity.ToTable("mail_model");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Context).HasColumnType("varchar(255)");

                entity.Property(e => e.Title).HasColumnType("varchar(255)");

                entity.Property(e => e.Type).HasColumnType("int(11)");
            });

            modelBuilder.Entity<MailType>(entity =>
            {
                entity.ToTable("mail_type");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Name).HasColumnType("varchar(255)");

                entity.Property(e => e.SonType).HasColumnType("varchar(255)");

                entity.Property(e => e.Type).HasColumnType("int(255)");
            });

            modelBuilder.Entity<SysDepartment>(entity =>
            {
                entity.ToTable("sys_department");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Leader).HasColumnType("int(255)");

                entity.Property(e => e.Name).HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<SysPosition>(entity =>
            {
                entity.ToTable("sys_position");

                entity.HasIndex(e => e.Department)
                    .HasName("deparment");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Department)
                    .HasColumnName("department")
                    .HasColumnType("int(255)");

                entity.Property(e => e.Name).HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<SysUserinfo>(entity =>
            {
                entity.ToTable("sys_userinfo");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Authority)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Department).HasColumnType("int(200)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.LastLogin)
                    .IsRequired()
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Position).HasColumnType("int(255)");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<UserMail>(entity =>
            {
                entity.ToTable("user_mail");

                entity.HasIndex(e => e.UserId)
                    .HasName("ID");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CrateDate)
                    .HasColumnType("datetime")
                    ;

                entity.Property(e => e.EndDate).HasColumnType("varchar(200)");

                entity.Property(e => e.Location).HasColumnType("varchar(20)");

                entity.Property(e => e.PeopleNum).HasColumnType("int(11)");

                entity.Property(e => e.Reason).HasColumnType("varchar(500)");

                entity.Property(e => e.StartDate).HasColumnType("varchar(200)");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.SumDay).HasColumnType("float(10,0)");

                entity.Property(e => e.Type).HasColumnType("varchar(255)");

                entity.Property(e => e.UserId).HasColumnType("int(20)");
            });

            modelBuilder.Entity<UserVocation>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("user_vocation");

                entity.Property(e => e.UserId).HasColumnType("int(255)");

                entity.Property(e => e.Log).HasColumnType("text");

                entity.Property(e => e.Update)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();
            });
        }
    }
}
