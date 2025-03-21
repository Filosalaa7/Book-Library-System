using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models;

namespace RepositoryPatternWithUOW.EF.Repositories
{
    public class BooksRepository : BaseRepository<Book>, IBooksRepository
    {
        private readonly ApplicationDbContext _context;
        public BooksRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Book Add(Book model)
        {
            _context.Set<Book>().Add(model);
            return model;
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books.Where(b => !b.IsBorrowed).ToList();
        }

        public bool UpdateBookState(int bookId)
        {
            var model = _context.Books.Find(bookId);
            model.IsBorrowed = !model.IsBorrowed;
            return model.IsBorrowed;
        }
    }
}
