using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models;

namespace RepositoryPatternWithUOW.EF.Repositories
{
    public class BorrowedRepository : BaseRepository<BorrowedBook>, IBorrowedRepository
    {
        private readonly ApplicationDbContext _context;
        public BorrowedRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public BorrowedBook Add(BorrowedBook model)
        {
            _context.Set<BorrowedBook>().Add(model);
            return model;
        }
    }
}
