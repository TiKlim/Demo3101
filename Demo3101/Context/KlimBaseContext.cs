using System;
using System.Collections.Generic;
using Demo3101.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo3101.Context;

public partial class KlimBaseContext : DbContext
{
    public KlimBaseContext()
    {
    }

    public KlimBaseContext(DbContextOptions<KlimBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<Office> Offices { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<StaffPost> StaffPosts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=89.110.53.87:5522; Database=klim_base; Username=klim; Password=nissan");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => new { e.DivId, e.DepId, e.SubDepId }).HasName("departments_pk");

            entity.ToTable("departments", "demo3101");

            entity.Property(e => e.DivId).HasColumnName("div_id");
            entity.Property(e => e.DepId).HasColumnName("dep_id");
            entity.Property(e => e.SubDepId).HasColumnName("sub_dep_id");

            entity.HasOne(d => d.Dep).WithMany(p => p.DepartmentDeps)
                .HasForeignKey(d => d.DepId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("departments_division_fk_1");

            entity.HasOne(d => d.Div).WithMany(p => p.DepartmentDivs)
                .HasForeignKey(d => d.DivId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("departments_division_fk");

            entity.HasOne(d => d.SubDep).WithMany(p => p.DepartmentSubDeps)
                .HasForeignKey(d => d.SubDepId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("departments_division_fk_2");
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.HasKey(e => e.DivisionId).HasName("division_pk");

            entity.ToTable("division", "demo3101");

            entity.Property(e => e.DivisionId)
                .ValueGeneratedNever()
                .HasColumnName("division_id");
            entity.Property(e => e.DivisionName)
                .HasColumnType("character varying")
                .HasColumnName("division_name");
        });

        modelBuilder.Entity<Office>(entity =>
        {
            entity.HasKey(e => e.OfficeId).HasName("office_pk");

            entity.ToTable("office", "demo3101");

            entity.Property(e => e.OfficeId)
                .ValueGeneratedNever()
                .HasColumnName("office_id");
            entity.Property(e => e.OfficeName)
                .HasColumnType("character varying")
                .HasColumnName("office_name");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("post_pk");

            entity.ToTable("post", "demo3101");

            entity.Property(e => e.PostId)
                .ValueGeneratedNever()
                .HasColumnName("post_id");
            entity.Property(e => e.PostName)
                .HasColumnType("character varying")
                .HasColumnName("post_name");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("staff_pk");

            entity.ToTable("staff", "demo3101");

            entity.Property(e => e.StaffId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("staff_id");
            entity.Property(e => e.CorporateEmail)
                .HasColumnType("character varying")
                .HasColumnName("corporate_email");
            entity.Property(e => e.StaffBirthday).HasColumnName("staff_birthday");
            entity.Property(e => e.StaffName)
                .HasColumnType("character varying")
                .HasColumnName("staff_name");
            entity.Property(e => e.StaffOffice).HasColumnName("staff_office");
            entity.Property(e => e.StaffPatronimic)
                .HasColumnType("character varying")
                .HasColumnName("staff_patronimic");
            entity.Property(e => e.StaffSurname)
                .HasColumnType("character varying")
                .HasColumnName("staff_surname");
            entity.Property(e => e.StaffWorkPhone)
                .HasColumnType("character varying")
                .HasColumnName("staff_work_phone");

            entity.HasOne(d => d.StaffOfficeNavigation).WithMany(p => p.Staff)
                .HasForeignKey(d => d.StaffOffice)
                .HasConstraintName("staff_office_fk");
        });

        modelBuilder.Entity<StaffPost>(entity =>
        {
            entity.HasKey(e => new { e.StaffId, e.DivisionId, e.PostId }).HasName("staff_post_pk");

            entity.ToTable("staff_post", "demo3101");

            entity.Property(e => e.StaffId).HasColumnName("staff_id");
            entity.Property(e => e.DivisionId).HasColumnName("division_id");
            entity.Property(e => e.PostId).HasColumnName("post_id");

            entity.HasOne(d => d.Division).WithMany(p => p.StaffPosts)
                .HasForeignKey(d => d.DivisionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("staff_post_division_fk");

            entity.HasOne(d => d.Post).WithMany(p => p.StaffPosts)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("staff_post_post_fk");

            entity.HasOne(d => d.Staff).WithMany(p => p.StaffPosts)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("staff_post_staff_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
