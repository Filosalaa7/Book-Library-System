using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models.Authentication;
using RepositoryPatternWithUOW.Core.Models.Tables;

namespace RepositoryPatternWithUOW.EF.Repositories
{
    public class BooksRepository : BaseRepository<Book>, IBooksRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IBorrowedRepository _borrowedRepository;
        public BooksRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IBorrowedRepository borrowedBook) : base(context)
        {
            _context = context;
            _userManager = userManager;
            _borrowedRepository = borrowedBook;
        }

        public Book Add(Book model)
        {
            _context.Set<Book>().Add(model);
            return model;
        }

        public IEnumerable<Book> GetAllAvailable()
        {
            return _context.Books.Where(b => !b.IsBorrowed).ToList();
        }
        public IEnumerable<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public bool BorrowBook(int bookId, string userId)
        {
            var book = _context.Books.Find(bookId);
            var user = _userManager.FindByIdAsync(userId);

            if (book is null || user is null || book.IsBorrowed)
                return false;
            else
            {
                book.IsBorrowed = true;
                var borrowedBook = new BorrowedBook
                {
                    BookId = bookId,
                    UserId = userId,
                    BorrowDate = DateTime.UtcNow,
                    ReturnDate = null // Null until returned
                };

                _borrowedRepository.Add(borrowedBook);
                return book.IsBorrowed;
            }
        }

        public bool ReturnBook(int bookId, string userId)
        {
            var book = _context.Books.Find(bookId);
            var user = _userManager.FindByIdAsync(userId);

            if (book is null || user is null || book.IsBorrowed)
                return false;
            else
            {
                book.IsBorrowed = false;
                var borrowedBook = _borrowedRepository.Find(b => b.BookId == bookId && b.UserId == userId);
                borrowedBook.ReturnDate = DateTime.UtcNow;
                return !book.IsBorrowed;

            }

        }
    }
}
