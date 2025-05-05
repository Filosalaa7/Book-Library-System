using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPatternWithUOW.Core.Models.Authentication;

namespace RepositoryPatternWithUOW.Core.Models.Tables
{
    public class BorrowedBook
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int BookId { get; set; } 

        public DateTime BorrowDate { get; set; } = DateTime.UtcNow;
        public DateTime? ReturnDate { get; set; }
        public bool IsReturned => ReturnDate.HasValue;

        public ApplicationUser User { get; set; }
        public Book Book { get; set; }
    }

}
