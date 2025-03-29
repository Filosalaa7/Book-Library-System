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
        public int Id { get; set; } // Primary Key
        public string UserId { get; set; } // FK to AspNetUsers
        public int BookId { get; set; }    // FK to Book

        public DateTime BorrowDate { get; set; } = DateTime.UtcNow;
        public DateTime? ReturnDate { get; set; }
        public bool IsReturned => ReturnDate.HasValue;

        // Navigation properties
        public ApplicationUser User { get; set; }
        public Book Book { get; set; }
    }

}
