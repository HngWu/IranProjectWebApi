using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IranProject.Models;

public partial class IranProjectContext : DbContext
{
    public IranProjectContext()
    {
    }

    public IranProjectContext(DbContextOptions<IranProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Saloon> Saloons { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Survey> Surveys { get; set; }

    public virtual DbSet<SurveyAnswer> SurveyAnswers { get; set; }

    public virtual DbSet<SurveyOption> SurveyOptions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    public virtual DbSet<WorkshopRequest> WorkshopRequests { get; set; }

    public virtual DbSet<WorkshopTime> WorkshopTimes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=IranProject;Trusted_Connection=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.CategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<Saloon>(entity =>
        {
            entity.ToTable("Saloon");

            entity.Property(e => e.SaloonName).HasMaxLength(100);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("Status");

            entity.Property(e => e.StatusName).HasMaxLength(50);
        });

        modelBuilder.Entity<Survey>(entity =>
        {
            entity.ToTable("Survey");

            entity.Property(e => e.Question).HasMaxLength(1000);
            entity.Property(e => e.SurveyName).HasMaxLength(50);
        });

        modelBuilder.Entity<SurveyAnswer>(entity =>
        {
            entity.ToTable("SurveyAnswer");

            entity.HasOne(d => d.Survey).WithMany(p => p.SurveyAnswers)
                .HasForeignKey(d => d.SurveyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Survey_SurveyAnswer");

            entity.HasOne(d => d.SurveyOption).WithMany(p => p.SurveyAnswers)
                .HasForeignKey(d => d.SurveyOptionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SurveyOption_SurveyAnswer");

            entity.HasOne(d => d.User).WithMany(p => p.SurveyAnswers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_ServeyAnswer");
        });

        modelBuilder.Entity<SurveyOption>(entity =>
        {
            entity.ToTable("SurveyOption");

            entity.Property(e => e.SurveyOptionName).HasMaxLength(50);

            entity.HasOne(d => d.Survey).WithMany(p => p.SurveyOptions)
                .HasForeignKey(d => d.SurveyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Survey_SurveyOption");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId).ValueGeneratedOnAdd();
            entity.Property(e => e.Fullname).HasMaxLength(50);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.UserNavigation).WithOne(p => p.User)
                .HasForeignKey<User>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserType_User");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.ToTable("UserType");

            entity.Property(e => e.UserTypeName)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<WorkshopRequest>(entity =>
        {
            entity.ToTable("WorkshopRequest");

            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.WorkshopRequests)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Category_WorkshopRequest");

            entity.HasOne(d => d.Saloon).WithMany(p => p.WorkshopRequests)
                .HasForeignKey(d => d.SaloonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Saloon_WorkshopRequest");

            entity.HasOne(d => d.User).WithMany(p => p.WorkshopRequests)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_WorkshopRequest");

            entity.HasOne(d => d.WorkshopTime).WithMany(p => p.WorkshopRequests)
                .HasForeignKey(d => d.WorkshopTimeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkshopTime_WorkshopRequest");
        });

        modelBuilder.Entity<WorkshopTime>(entity =>
        {
            entity.ToTable("WorkshopTime");

            entity.Property(e => e.Description).HasMaxLength(1000);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
