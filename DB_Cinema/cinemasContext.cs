using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DB_Cinema
{
    public partial class cinemasContext : DbContext
    {
        public cinemasContext()
        {
        }

        public cinemasContext(DbContextOptions<cinemasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cinema> Cinemas { get; set; }
        public virtual DbSet<CinemaHall> CinemaHalls { get; set; }
        public virtual DbSet<CinemaSeat> CinemaSeats { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Show> Shows { get; set; }
        public virtual DbSet<ShowSeat> ShowSeats { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=cinemas;Username=postgres;Password=yulya200220");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cinema>(entity =>
            {
                entity.ToTable("cinema");

                entity.HasIndex(e => e.CityId, "fki_CityID");

                entity.Property(e => e.CinemaId)
                    .ValueGeneratedNever()
                    .HasColumnName("cinema_id");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.QuantityOfCinemaHalls).HasColumnName("quantity_of_cinema_halls");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Cinemas)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("CityID");
            });

            modelBuilder.Entity<CinemaHall>(entity =>
            {
                entity.ToTable("cinema_hall");

                entity.HasIndex(e => e.CinemaId, "fki_CinemaID");

                entity.Property(e => e.CinemaHallId)
                    .ValueGeneratedNever()
                    .HasColumnName("cinema_hall_id");

                entity.Property(e => e.CinemaId).HasColumnName("cinema_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.TotalSeats).HasColumnName("total_seats");

                entity.HasOne(d => d.Cinema)
                    .WithMany(p => p.CinemaHalls)
                    .HasForeignKey(d => d.CinemaId)
                    .HasConstraintName("CinemaID");
            });

            modelBuilder.Entity<CinemaSeat>(entity =>
            {
                entity.ToTable("cinema_seat");

                entity.HasIndex(e => e.CinemaHallId, "fki_CinemaHallID");

                entity.Property(e => e.CinemaSeatId)
                    .ValueGeneratedNever()
                    .HasColumnName("cinema_seat_id");

                entity.Property(e => e.CinemaHallId).HasColumnName("cinema_hall_id");

                entity.Property(e => e.SeatNumber).HasColumnName("seat_number");

                entity.HasOne(d => d.CinemaHall)
                    .WithMany(p => p.CinemaSeats)
                    .HasForeignKey(d => d.CinemaHallId)
                    .HasConstraintName("CinemaHallID");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.Property(e => e.CityId)
                    .ValueGeneratedNever()
                    .HasColumnName("city_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .HasColumnName("state");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("movie");

                entity.Property(e => e.MovieId)
                    .ValueGeneratedNever()
                    .HasColumnName("movie_id");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .HasColumnName("country");

                entity.Property(e => e.Duration)
                    .HasColumnType("time without time zone")
                    .HasColumnName("duration");

                entity.Property(e => e.Genre)
                    .HasMaxLength(30)
                    .HasColumnName("genre");

                entity.Property(e => e.Language)
                    .HasMaxLength(20)
                    .HasColumnName("language");

                entity.Property(e => e.ReleaseDate)
                    .HasColumnType("date")
                    .HasColumnName("release_date");

                entity.Property(e => e.Title)
                    .HasMaxLength(200)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Show>(entity =>
            {
                entity.ToTable("show");

                entity.HasIndex(e => e.MovieId, "fki_MovieID");

                entity.Property(e => e.ShowId)
                    .ValueGeneratedNever()
                    .HasColumnName("show_id");

                entity.Property(e => e.CinemaHallId).HasColumnName("cinema_hall_id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.EndTime)
                    .HasColumnType("time without time zone")
                    .HasColumnName("end_time");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.Property(e => e.StartTime)
                    .HasColumnType("time without time zone")
                    .HasColumnName("start_time");

                entity.HasOne(d => d.CinemaHall)
                    .WithMany(p => p.Shows)
                    .HasForeignKey(d => d.CinemaHallId)
                    .HasConstraintName("CinemaHallID");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Shows)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("MovieID");
            });

            modelBuilder.Entity<ShowSeat>(entity =>
            {
                entity.ToTable("show_seat");

                entity.HasIndex(e => e.CinemaSeatId, "fki_CinemaSeatID");

                entity.HasIndex(e => e.TicketId, "fki_TicketID");

                entity.Property(e => e.ShowSeatId)
                    .ValueGeneratedNever()
                    .HasColumnName("show_seat_id");

                entity.Property(e => e.CinemaSeatId).HasColumnName("cinema_seat_id");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.ShowId).HasColumnName("show_id");

                entity.Property(e => e.TicketId).HasColumnName("ticket_id");

                entity.HasOne(d => d.CinemaSeat)
                    .WithMany(p => p.ShowSeats)
                    .HasForeignKey(d => d.CinemaSeatId)
                    .HasConstraintName("CinemaSeatID");

                entity.HasOne(d => d.Show)
                    .WithMany(p => p.ShowSeats)
                    .HasForeignKey(d => d.ShowId)
                    .HasConstraintName("ShowID");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.ShowSeats)
                    .HasForeignKey(d => d.TicketId)
                    .HasConstraintName("TicketID");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("ticket");

                entity.HasIndex(e => e.ShowId, "fki_ShowID");

                entity.Property(e => e.TicketId)
                    .ValueGeneratedNever()
                    .HasColumnName("ticket_id");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.ShowId).HasColumnName("show_id");

                entity.HasOne(d => d.Show)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.ShowId)
                    .HasConstraintName("ShowID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.TicketId, "fki_ticket");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .HasColumnName("last_name");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .HasColumnName("phone_number");

                entity.Property(e => e.TicketId).HasColumnName("ticket_id");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.TicketId)
                    .HasConstraintName("ticket");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
