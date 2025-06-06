﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.Core.Models.Tables
{
    public class Book
    {
        public int Id { get; set; }

        [Required, MaxLength(250)]
        public string Title { get; set; }

        public Author Author { get; set; }

        public bool IsBorrowed { get; set; }

        public int AuthorId { get; set; }

        public ICollection<BorrowedBook> BorrowedBooks { get; set; } = new List<BorrowedBook>();


    }
}
