using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GetYourCar.Models;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Itinerary> Itineraries { get; set; }

    public virtual DbSet<RightsCategory> RightsCategories { get; set; }

    public virtual DbSet<Route> Routes { get; set; }

    public virtual DbSet<TypeCar> TypeCars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=12332145");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("car_pkey");

            entity.ToTable("car");

            entity.HasIndex(e => e.StateNumber, "car_state_number_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdTypeCar).HasColumnName("id_type_car");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.NumberPassengers).HasColumnName("number_passengers");
            entity.Property(e => e.StateNumber)
                .HasMaxLength(10)
                .HasColumnName("state_number");

            entity.HasOne(d => d.IdTypeCarNavigation).WithMany(p => p.Cars)
                .HasForeignKey(d => d.IdTypeCar)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("car_id_type_car_fkey");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("driver_pkey");

            entity.ToTable("driver");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");

            entity.HasMany(d => d.IdRightsCategories).WithMany(p => p.IdDrivers)
                .UsingEntity<Dictionary<string, object>>(
                    "DriverRightsCategory",
                    r => r.HasOne<RightsCategory>().WithMany()
                        .HasForeignKey("IdRightsCategory")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("driver_rights_category_id_rights_category_fkey"),
                    l => l.HasOne<Driver>().WithMany()
                        .HasForeignKey("IdDriver")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("driver_rights_category_id_driver_fkey"),
                    j =>
                    {
                        j.HasKey("IdDriver", "IdRightsCategory").HasName("driver_rights_category_pkey");
                        j.ToTable("driver_rights_category");
                        j.IndexerProperty<int>("IdDriver").HasColumnName("id_driver");
                        j.IndexerProperty<int>("IdRightsCategory").HasColumnName("id_rights_category");
                    });
        });

        modelBuilder.Entity<Itinerary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("itinerary_pkey");

            entity.ToTable("itinerary");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<RightsCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rights_category_pkey");

            entity.ToTable("rights_category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(5)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Route>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("route_pkey");

            entity.ToTable("route");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdCar).HasColumnName("id_car");
            entity.Property(e => e.IdDriver).HasColumnName("id_driver");
            entity.Property(e => e.IdItinerary).HasColumnName("id_itinerary");
            entity.Property(e => e.NumberPassengers).HasColumnName("number_passengers");

            entity.HasOne(d => d.IdCarNavigation).WithMany(p => p.Routes)
                .HasForeignKey(d => d.IdCar)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("route_id_car_fkey");

            entity.HasOne(d => d.IdDriverNavigation).WithMany(p => p.Routes)
                .HasForeignKey(d => d.IdDriver)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("route_id_driver_fkey");

            entity.HasOne(d => d.IdItineraryNavigation).WithMany(p => p.Routes)
                .HasForeignKey(d => d.IdItinerary)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("route_id_itinerary_fkey");
        });

        modelBuilder.Entity<TypeCar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("type_car_pkey");

            entity.ToTable("type_car");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
