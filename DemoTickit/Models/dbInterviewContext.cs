using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace DemoTicket.Models
{
    public partial class dbInterviewContext : DbContext
    {
        public IConfiguration Configuration { get; }
        public dbInterviewContext()
        {
        }

        public dbInterviewContext(DbContextOptions<dbInterviewContext> options,IConfiguration _configuration)
            : base(options)
        {
            Configuration = _configuration;
        }

        public virtual DbSet<Buyer> Buyer { get; set; }
        public virtual DbSet<Event> Event { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SQLConnection"));
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Server=dbinterview9.database.windows.net;user=dbinterview9user;Password=Hxes-Ku2Eqc6)x8u;Database=dbInterview");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buyer>(entity =>
            {
                entity.Property(e => e.BuyerName)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.TesterKey)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Buyer)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_Guess_Contest");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TimeoutInSeconds).HasDefaultValueSql("((300))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
