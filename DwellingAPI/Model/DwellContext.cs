using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DwellingAPI.Model
{
    public partial class DwellContext : DbContext
    {
        public DwellContext()
        {
        }

        public DwellContext(DbContextOptions<DwellContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Rooms> Rooms { get; set; }
        public virtual DbSet<Routines> Routines { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=tcp:darjeeling.database.windows.net,1433;Initial Catalog=Dwelling;Persist Security Info=False;User ID=TeaAdmin;Password=Coolduder1ng;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).ValueGeneratedNever();

                entity.Property(e => e.Category1).IsUnicode(false);
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PK__Items__727E83EB065A0C53");

                entity.Property(e => e.ItemId).ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.ItemName).IsUnicode(false);

                entity.Property(e => e.Starred).IsUnicode(false);

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Category)
                    .HasConstraintName("FK__Items__Category__5629CD9C");

                entity.HasOne(d => d.RoomNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Room)
                    .HasConstraintName("FK__Items__Room__5441852A");

                entity.HasOne(d => d.TagNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Tag)
                    .HasConstraintName("FK__Items__Tag__5535A963");
            });

            modelBuilder.Entity<Rooms>(entity =>
            {
                entity.HasKey(e => e.RoomId)
                    .HasName("PK__Rooms__328639198FBBB011");

                entity.Property(e => e.RoomId).ValueGeneratedNever();

                entity.Property(e => e.RoomName).IsUnicode(false);

                entity.Property(e => e.RoomState).IsUnicode(false);
            });

            modelBuilder.Entity<Routines>(entity =>
            {
                entity.HasKey(e => e.RoutineId)
                    .HasName("PK__Routines__A6E3E51ABE2DDF19");

                entity.Property(e => e.RoutineId).ValueGeneratedNever();

                entity.Property(e => e.Starred).IsUnicode(false);

                entity.Property(e => e.Todo).IsUnicode(false);
            });

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.HasKey(e => e.TagId)
                    .HasName("PK__Tags__657CFA4CA1DC05F7");

                entity.Property(e => e.TagId).ValueGeneratedNever();

                entity.Property(e => e.Tag).IsUnicode(false);
            });
        }
    }
}
