using System;
using System.Collections.Generic;
using Demo0203.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo0203.Context;

public partial class KlimBaseContext : DbContext
{
    public KlimBaseContext()
    {
    }

    public KlimBaseContext(DbContextOptions<KlimBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<MeetType> MeetTypes { get; set; }

    public virtual DbSet<MeetingsCalendar> MeetingsCalendars { get; set; }

    public virtual DbSet<Office> Offices { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=89.110.53.87:5522;Database=klim_base;Username=klim;Password=nissan");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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

            entity.HasMany(d => d.Idadditionaldevis).WithMany(p => p.Idmaindevisions)
                .UsingEntity<Dictionary<string, object>>(
                    "Dep",
                    r => r.HasOne<Division>().WithMany()
                        .HasForeignKey("Idadditionaldevi")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("dep_division_fk_1"),
                    l => l.HasOne<Division>().WithMany()
                        .HasForeignKey("Idmaindevision")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("dep_division_fk"),
                    j =>
                    {
                        j.HasKey("Idadditionaldevi", "Idmaindevision").HasName("dep_pk");
                        j.ToTable("dep", "demo3101");
                        j.IndexerProperty<int>("Idadditionaldevi").HasColumnName("idadditionaldevi");
                        j.IndexerProperty<int>("Idmaindevision").HasColumnName("idmaindevision");
                    });

            entity.HasMany(d => d.Idmaindevisions).WithMany(p => p.Idadditionaldevis)
                .UsingEntity<Dictionary<string, object>>(
                    "Dep",
                    r => r.HasOne<Division>().WithMany()
                        .HasForeignKey("Idmaindevision")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("dep_division_fk"),
                    l => l.HasOne<Division>().WithMany()
                        .HasForeignKey("Idadditionaldevi")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("dep_division_fk_1"),
                    j =>
                    {
                        j.HasKey("Idadditionaldevi", "Idmaindevision").HasName("dep_pk");
                        j.ToTable("dep", "demo3101");
                        j.IndexerProperty<int>("Idadditionaldevi").HasColumnName("idadditionaldevi");
                        j.IndexerProperty<int>("Idmaindevision").HasColumnName("idmaindevision");
                    });

            entity.HasMany(d => d.Idstaffs).WithMany(p => p.Iddepats)
                .UsingEntity<Dictionary<string, object>>(
                    "DepartStaff",
                    r => r.HasOne<Staff>().WithMany()
                        .HasForeignKey("Idstaff")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("departstaff_staff_fk"),
                    l => l.HasOne<Division>().WithMany()
                        .HasForeignKey("Iddepat")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("departstaff_division_fk"),
                    j =>
                    {
                        j.HasKey("Iddepat", "Idstaff").HasName("departstaff_pk");
                        j.ToTable("departStaff", "demo3101");
                        j.IndexerProperty<int>("Iddepat").HasColumnName("iddepat");
                        j.IndexerProperty<int>("Idstaff").HasColumnName("idstaff");
                    });
        });

        modelBuilder.Entity<MeetType>(entity =>
        {
            entity.HasKey(e => e.MeetTypeId).HasName("meet_types_pk");

            entity.ToTable("meet_types", "demo3101");

            entity.Property(e => e.MeetTypeId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("meet_type_id");
            entity.Property(e => e.MeetTypeName)
                .HasColumnType("character varying")
                .HasColumnName("meet_type_name");
        });

        modelBuilder.Entity<MeetingsCalendar>(entity =>
        {
            entity.HasKey(e => e.MeetId).HasName("meetings_calendar_pk");

            entity.ToTable("meetings_calendar", "demo3101");

            entity.Property(e => e.MeetId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("meet_id");
            entity.Property(e => e.MeetDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("meet_date");
            entity.Property(e => e.MeetDescription)
                .HasColumnType("character varying")
                .HasColumnName("meet_description");
            entity.Property(e => e.MeetName)
                .HasColumnType("character varying")
                .HasColumnName("meet_name");
            entity.Property(e => e.MeetStaff).HasColumnName("meet_staff");
            entity.Property(e => e.MeetStatus).HasColumnName("meet_status");
            entity.Property(e => e.MeetTimeFinish).HasColumnName("meet_time_finish");
            entity.Property(e => e.MeetTimeStart).HasColumnName("meet_time_start");
            entity.Property(e => e.MeetType).HasColumnName("meet_type");

            entity.HasOne(d => d.MeetStaffNavigation).WithMany(p => p.MeetingsCalendars)
                .HasForeignKey(d => d.MeetStaff)
                .HasConstraintName("meetings_calendar_staff_fk");

            entity.HasOne(d => d.MeetTypeNavigation).WithMany(p => p.MeetingsCalendars)
                .HasForeignKey(d => d.MeetType)
                .HasConstraintName("meetings_calendar_meet_types_fk");

            entity.HasMany(d => d.BirthDates).WithMany(p => p.MeetDates)
                .UsingEntity<Dictionary<string, object>>(
                    "CalendarDate",
                    r => r.HasOne<Staff>().WithMany()
                        .HasForeignKey("BirthDates")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("calendar_dates_staff_fk"),
                    l => l.HasOne<MeetingsCalendar>().WithMany()
                        .HasForeignKey("MeetDates")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("calendar_dates_meetings_calendar_fk"),
                    j =>
                    {
                        j.HasKey("MeetDates", "BirthDates").HasName("calendar_dates_pk");
                        j.ToTable("calendar_dates", "demo3101");
                        j.IndexerProperty<int>("MeetDates").HasColumnName("meet_dates");
                        j.IndexerProperty<int>("BirthDates").HasColumnName("birth_dates");
                    });
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

            entity.HasMany(d => d.Idstaffs).WithMany(p => p.Idroles)
                .UsingEntity<Dictionary<string, object>>(
                    "StaffRole",
                    r => r.HasOne<Staff>().WithMany()
                        .HasForeignKey("Idstaff")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("staffrole_staff_fk"),
                    l => l.HasOne<Post>().WithMany()
                        .HasForeignKey("Idrole")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("staffrole_post_fk"),
                    j =>
                    {
                        j.HasKey("Idrole", "Idstaff").HasName("staffrole_pk");
                        j.ToTable("staffRole", "demo3101");
                        j.IndexerProperty<int>("Idrole").HasColumnName("idrole");
                        j.IndexerProperty<int>("Idstaff").HasColumnName("idstaff");
                    });
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
            entity.Property(e => e.StaffBirthday)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("staff_birthday");
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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
