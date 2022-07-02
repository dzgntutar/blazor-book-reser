using BookReservation.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservation.Data.Context
{
    public class ReservationDbContext : DbContext
    {
        public ReservationDbContext(DbContextOptions<ReservationDbContext> options) : base(options)
        {
        }

        DbSet<Book> Books { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<ReservedBook> ReservedBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.CreateDate).IsRequired();
                entity.Property(s => s.UpdateDate);
                entity.Property(s => s.CreateBy).IsRequired();
                entity.Property(s => s.UpdateDate);
                entity.Property(s => s.Name).IsRequired().HasMaxLength(50);
                entity.Property(s => s.PublishDate);
                entity.Property(s => s.Author);
                entity.Property(s => s.PublishDate);
                entity.Property(s => s.Count);
            });


            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.CreateDate).IsRequired();
                entity.Property(s => s.UpdateDate);
                entity.Property(s => s.CreateBy).IsRequired();
                entity.Property(s => s.UpdateDate);
                entity.Property(s => s.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(s => s.LastName).IsRequired().HasMaxLength(50);
                entity.Property(s => s.UserName).IsRequired().HasMaxLength(50);
                entity.Property(s => s.Password).IsRequired();
                entity.Property(s => s.EmailAddress).IsRequired();
            });

            modelBuilder.Entity<Book>()
                                       .HasMany(s => s.Users)
                                       .WithMany(s => s.Books)
                                       .UsingEntity<ReservedBook>(
                                            j => j.HasOne(s => s.User).WithMany(s => s.ReservedBooks).HasForeignKey(s => s.UserId),
                                            j => j.HasOne(s => s.Book).WithMany(s => s.ReservedBooks).HasForeignKey(s => s.BookId),
                                            j =>
                                            {
                                                j.HasKey(s => s.Id);
                                                j.Property(s => s.CreateDate).IsRequired(); ;
                                                j.Property(s => s.UpdateDate);
                                                j.Property(s => s.CreateBy).IsRequired();
                                                j.Property(s => s.UpdateDate);
                                                j.Property(s => s.ReservedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                                                j.Property(s => s.ReservedFinishDate).IsRequired();
                                                j.HasKey(t => new { t.BookId, t.UserId });
                                            }
                                        );
            base.OnModelCreating(modelBuilder);
        }
    }
}
