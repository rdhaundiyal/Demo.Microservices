using Microsoft.EntityFrameworkCore;
using Demo.Microservices.Services.Entities;
namespace Demo.Microservices.Services.NewsService.Providers
{
    public partial class NewsDbContext : DbContext
    {
        

        public NewsDbContext(DbContextOptions<NewsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<Entities.News> News { get; set; }
        public virtual DbSet<NewsSource> NewsSource { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=LAPTOP-6U9AOJQ2;Database=NewsIndia;User ID=sa;Password=Passw0rd;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Images>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ImagePath)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.NewsId).HasColumnName("NewsID");

                entity.HasOne(d => d.News)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.NewsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Images_News");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PublishDate).HasColumnType("datetime");

                entity.HasOne(d => d.Source)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.SourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_News_NewsSource");
            });

            modelBuilder.Entity<NewsSource>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.NewsSource)
                    .HasForeignKey(d => d.Country)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NewsSource_Countries1");
            });
        }
    }
}
