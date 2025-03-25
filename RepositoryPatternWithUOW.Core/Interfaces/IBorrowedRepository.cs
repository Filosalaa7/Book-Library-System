using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPatternWithUOW.Core.Models;

namespace RepositoryPatternWithUOW.Core.Interfaces
{
    public interface IBorrowedRepository : IBaseRepository<BorrowedBook>
    {
        BorrowedBook Add(BorrowedBook model);
    }
}
