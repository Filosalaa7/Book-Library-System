using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUOW.Core.Models.Authentication;
using RepositoryPatternWithUOW.Core.Models.Tables;

namespace RepositoryPatternWithUOW.EF
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        internal readonly object BorrowedBooks;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Always call base for Identity setup

            modelBuilder.Entity<BorrowedBook>()
       .HasKey(bb => bb.Id); // Primary Key

            modelBuilder.Entity<BorrowedBook>()
                .HasOne(bb => bb.User)
                .WithMany(u => u.BorrowedBooks)
                .HasForeignKey(bb => bb.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BorrowedBook>()
                .HasOne(bb => bb.Book)
                .WithMany(b => b.BorrowedBooks)
                .HasForeignKey(bb => bb.BookId)
                .OnDelete(DeleteBehavior.Cascade);
        }

         public DbSet<Author> Authors { get; set; }
         public DbSet<Book> Books { get; set; }
    }
}
