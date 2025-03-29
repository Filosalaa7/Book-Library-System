using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models.Authentication;
using RepositoryPatternWithUOW.Core.Models.Tables;
using RepositoryPatternWithUOW.EF.Repositories;

namespace RepositoryPatternWithUOW.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IBorrowedRepository _borrowedBook;
        public IBaseRepository<Author> Authors { get; private set; }

        public IBooksRepository Books { get; private set; }
        public IBorrowedRepository BorrowedBooks => _borrowedBook;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IBorrowedRepository borrowedBook)
        {
            _context = context;
            _userManager = userManager;
            _borrowedBook = borrowedBook;
            Authors = new BaseRepository<Author>(_context);
            Books = new BooksRepository(_context, _userManager, _borrowedBook);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
