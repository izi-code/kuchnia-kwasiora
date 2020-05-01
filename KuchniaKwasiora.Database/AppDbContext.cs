using KuchniaKwasiora.Domain.Models;
using KuchniaKwasiora.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KuchniaKwasiora.Database
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString;
        private readonly bool _useConsoleLogger;

        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        protected AppDbContext()
        {
        }

        public AppDbContext(string connectionString, bool useConsoleLogger) : this()
        {
            _connectionString = connectionString;
            _useConsoleLogger = useConsoleLogger;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter((category, level) =>
                        category == DbLoggerCategory.Database.Command.Name &&
                        level == LogLevel.Information)
                    .AddConsole();
            });

            optionsBuilder
                .UseSqlServer(_connectionString);

            if (_useConsoleLogger)
            {
                optionsBuilder
                    .UseLoggerFactory(loggerFactory)
                    .EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(x =>
            {
                x.ToTable("User").HasKey(k => k.Id);

                x.Property(p => p.Id).ValueGeneratedOnAdd();
                x.Property(p => p.FirstName).IsRequired();
                x.Property(p => p.Email).IsRequired();
                x.Property(p => p.Email)
                    .HasConversion(email => email.Value, email => Email.Create(email).Value);
            });

            modelBuilder.Entity<Post>(x =>
            {
                x.ToTable("Post").HasKey(k => k.Id);
                x.HasOne(p => p.User).WithMany();

                x.Property(p => p.Id).ValueGeneratedOnAdd();
                x.Property(p => p.Content).IsRequired();
            });
        }
    }
}
