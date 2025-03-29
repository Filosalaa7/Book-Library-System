using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUOW.Core.Models.Tables;

namespace RepositoryPatternWithUOW.Core.Interfaces
{
    public interface IBooksRepository : IBaseRepository<Book>
    {
        public IEnumerable<Book> GetAllAvailable();
        public IEnumerable<Book> GetAll();

        bool BorrowBook(int bookId, string userId);
        bool ReturnBook(int bookId, string userId);
        Book Add(Book model);
    }
}
