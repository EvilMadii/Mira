using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using api.models.dbEntities;

namespace api.dal;

public partial class RailwayContext : DbContext
{
    private readonly string _connStr;
    public RailwayContext()
    {
        _connStr = new ConfigurationBuilder().AddUserSecrets<RailwayContext>().Build()["connectionstring:main"];
    }

    public RailwayContext(DbContextOptions<RailwayContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Note> Notes { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Projectstatus> Projectstatuses { get; set; }

    public virtual DbSet<Repository> Repositories { get; set; }

    public virtual DbSet<Todo> Todos { get; set; }

    public virtual DbSet<TodoStatus> TodoStatuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql(_connStr);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("timescaledb");

        modelBuilder.Entity<Note>(entity =>
        {
            entity.HasKey(e => e.NoteId).HasName("NOTE_pkey");

            entity.ToTable("NOTE");

            entity.Property(e => e.NoteId)
                .HasMaxLength(101)
                .HasColumnName("NOTE_ID");
            entity.Property(e => e.NoteBody).HasColumnName("NOTE_BODY");
            entity.Property(e => e.NoteTitle)
                .HasMaxLength(50)
                .HasColumnName("NOTE_TITLE");
            entity.Property(e => e.ProjectId).HasColumnName("PROJECT_ID");

            entity.HasOne(d => d.Project).WithMany(p => p.Notes)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PROJECT_NOTE");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PROJECT_pkey");

            entity.ToTable("PROJECT");

            entity.Property(e => e.ProjectId)
                .ValueGeneratedNever()
                .HasColumnName("PROJECT_ID");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(50)
                .HasColumnName("PROJECT_NAME");
            entity.Property(e => e.ProjectScope).HasColumnName("PROJECT_SCOPE");
            entity.Property(e => e.ProjectStatusId).HasColumnName("PROJECT_STATUS_ID");
            entity.Property(e => e.UserId).HasColumnName("USER_ID");

            entity.HasOne(d => d.ProjectStatus).WithMany(p => p.Projects)
                .HasForeignKey(d => d.ProjectStatusId)
                .HasConstraintName("FK_PROJECT_STATUS_PROJECT");

            entity.HasOne(d => d.User).WithMany(p => p.Projects)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USER_PROJECT");
        });

        modelBuilder.Entity<Projectstatus>(entity =>
        {
            entity.HasKey(e => e.ProjectStatusId).HasName("PROJECTSTATUS_pkey");

            entity.ToTable("PROJECTSTATUS");

            entity.Property(e => e.ProjectStatusId)
                .ValueGeneratedNever()
                .HasColumnName("PROJECT_STATUS_ID");
            entity.Property(e => e.ProjectStatusName)
                .HasMaxLength(20)
                .HasColumnName("PROJECT_STATUS_NAME");
        });

        modelBuilder.Entity<Repository>(entity =>
        {
            entity.HasKey(e => e.RepositoryId).HasName("Repository_pkey");

            entity.ToTable("Repository");

            entity.Property(e => e.RepositoryId).HasColumnName("Repository_ID");
            entity.Property(e => e.ProjectId).HasColumnName("PROJECT_ID");
            entity.Property(e => e.RepositoryName).HasColumnName("Repository_Name");
            entity.Property(e => e.RepositoryUrl).HasColumnName("Repository_Url");

            entity.HasOne(d => d.Project).WithMany(p => p.Repositories)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PROJECT_REPOSITORY");
        });

        modelBuilder.Entity<Todo>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("Todos_pkey");

            entity.Property(e => e.TaskId)
                .ValueGeneratedNever()
                .HasColumnName("Task_ID");
            entity.Property(e => e.ProjectId).HasColumnName("PROJECT_ID");
            entity.Property(e => e.TaskDescription)
                .HasMaxLength(255)
                .HasColumnName("Task_Description");
            entity.Property(e => e.TaskEnd)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("Task_End");
            entity.Property(e => e.TaskName)
                .HasMaxLength(255)
                .HasColumnName("Task_Name");
            entity.Property(e => e.TaskStart)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("Task_Start");
            entity.Property(e => e.TaskStatusId).HasColumnName("TaskStatusID");

            entity.HasOne(d => d.Project).WithMany(p => p.Todos)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_PROJECT_TODOS");

            entity.HasOne(d => d.TaskStatus).WithMany(p => p.Todos)
                .HasForeignKey(d => d.TaskStatusId)
                .HasConstraintName("FK_TODO_STATUS_TODOS");
        });

        modelBuilder.Entity<TodoStatus>(entity =>
        {
            entity.HasKey(e => e.TaskStatusId).HasName("TodoStatus_pkey");

            entity.ToTable("TodoStatus");

            entity.Property(e => e.TaskStatusId)
                .ValueGeneratedNever()
                .HasColumnName("TaskStatusID");
            entity.Property(e => e.TaskStatusName).HasMaxLength(20);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("USER_pkey");

            entity.ToTable("USER");

            entity.HasIndex(e => e.Email, "USER_EMAIL_key").IsUnique();

            entity.HasIndex(e => e.Salt, "USER_SALT_key").IsUnique();

            entity.HasIndex(e => e.UserName, "USER_USER_NAME_key").IsUnique();

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("USER_ID");
            entity.Property(e => e.Datecreated)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("DATECREATED");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Isactive).HasColumnName("ISACTIVE");
            entity.Property(e => e.LastLogin)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("LAST_LOGIN");
            entity.Property(e => e.LastPfpUpdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("LAST_PFP_UPDATE");
            entity.Property(e => e.Password).HasColumnName("PASSWORD");
            entity.Property(e => e.Salt)
                .HasMaxLength(16)
                .HasColumnName("SALT");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("USER_NAME");
            entity.Property(e => e.UserProfileImageUrl).HasColumnName("USER_PROFILE_IMAGE_URL");
        });
        modelBuilder.HasSequence("chunk_constraint_name", "_timescaledb_catalog");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
