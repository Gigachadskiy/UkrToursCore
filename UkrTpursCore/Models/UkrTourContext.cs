using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UkrTpursCore.Models
{
    public enum RolesLayouts {Login = 0, Admins, Clients, Managers};
    public partial class UkrTourContext : DbContext
    {
        public static RolesLayouts ActiveRoleLayout = RolesLayouts.Login;
        public static User ActiveUser = null;


        public UkrTourContext()
        {

        }

        public UkrTourContext(DbContextOptions<UkrTourContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Excursion> Excursions { get; set; } = null!;
        public virtual DbSet<ExcursionsState> ExcursionsStates { get; set; } = null!;
        public virtual DbSet<ExcursionsUser> ExcursionsUsers { get; set; } = null!;
        public virtual DbSet<Hotel> Hotels { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Tour> Tours { get; set; } = null!;
        public virtual DbSet<ToursCity> ToursCities { get; set; } = null!;
        public virtual DbSet<ToursType> ToursTypes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=DESKTOP-8K7IO7A\\SQLEXPRESS;Database=UkrTour;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.Property(e => e.CreationDate).HasColumnType("date");

                entity.Property(e => e.Image).HasColumnType("image");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_Cities_Countries");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Excursion>(entity =>
            {
                entity.Property(e => e.DateFinish).HasColumnType("date");

                entity.Property(e => e.DateStart).HasColumnType("date");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Excursions)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Excursions_Albums");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Excursions)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_Excursions_ExcursionsState");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.Excursions)
                    .HasForeignKey(d => d.TourId)
                    .HasConstraintName("FK_Excursions_Tours");
            });

            modelBuilder.Entity<ExcursionsState>(entity =>
            {
                entity.ToTable("ExcursionsState");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<ExcursionsUser>(entity =>
            {
                entity.HasOne(d => d.Excursion)
                    .WithMany(p => p.ExcursionsUsers)
                    .HasForeignKey(d => d.ExcursionId)
                    .HasConstraintName("FK_ExcursionsUsers_Excursions");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ExcursionsUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ExcursionsUsers_Users");
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Hotels)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Hotels_Cities");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Tour>(entity =>
            {
                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.TourType)
                    .WithMany(p => p.Tours)
                    .HasForeignKey(d => d.TourTypeId)
                    .HasConstraintName("FK_Tours_ToursTypes");
            });

            modelBuilder.Entity<ToursCity>(entity =>
            {
                entity.HasOne(d => d.City)
                    .WithMany(p => p.ToursCities)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_ToursCities_Cities");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.ToursCities)
                    .HasForeignKey(d => d.TourId)
                    .HasConstraintName("FK_ToursCities_Tours");
            });

            modelBuilder.Entity<ToursType>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Surname).HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Users_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
