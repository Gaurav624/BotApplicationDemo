namespace MyBotApplicationDemo
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BookingContext : DbContext
    {
        public BookingContext()
            : base("name=BookingContext")
        {
        }

        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<MovieDetail> MovieDetails { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }
        public virtual DbSet<SeatsCategory> SeatsCategories { get; set; }
        public virtual DbSet<Show> Shows { get; set; }
        public virtual DbSet<TheatreCategory> TheatreCategories { get; set; }
        public virtual DbSet<Theatre> Theatres { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<BookingDetail> BookingDetails { get; set; }
        public virtual DbSet<Price> Prices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<MovieDetail>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<MovieDetail>()
                .Property(e => e.Genre)
                .IsUnicode(false);

            modelBuilder.Entity<SeatsCategory>()
                .Property(e => e.Category)
                .IsUnicode(false);

            modelBuilder.Entity<SeatsCategory>()
                .HasMany(e => e.Seats)
                .WithRequired(e => e.SeatsCategory)
                .HasForeignKey(e => e.SeatCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SeatsCategory>()
                .HasMany(e => e.Prices)
                .WithOptional(e => e.SeatsCategory)
                .HasForeignKey(e => e.SeatCategoryId);

            modelBuilder.Entity<Show>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Show>()
                .Property(e => e.Timings)
                .IsUnicode(false);

            modelBuilder.Entity<TheatreCategory>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<TheatreCategory>()
                .HasMany(e => e.Prices)
                .WithOptional(e => e.TheatreCategory)
                .HasForeignKey(e => e.TheatreCategoryId);

            modelBuilder.Entity<Theatre>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Emaild)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<BookingDetail>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Price>()
                .Property(e => e.Prices)
                .HasPrecision(18, 0);
        }
    }
}
