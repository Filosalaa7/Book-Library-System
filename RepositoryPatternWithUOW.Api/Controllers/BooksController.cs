﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.Constants;
using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models.Tables;

namespace RepositoryPatternWithUOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet("GetAllAvailable")]
        public IActionResult GetAllAvailable()
        {
            var book = _unitOfWork.Books.GetAllAvailable();
            return Ok(book);
        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var book = _unitOfWork.Books.GetAll();
            return Ok(book);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("AddBook")]
        public IActionResult AddOne([FromBody] Book request)
        {
            var book = _unitOfWork.Books.Add(request);
            _unitOfWork.Complete();
            return Ok(book);
        }

        [Authorize(Roles = "User,Admin")]
        [HttpPost("BorrowBook")]
        public IActionResult BorrowBooks(int BookId , string UserId)
        {
            var result = _unitOfWork.Books.BorrowBook(BookId,UserId);
            _unitOfWork.Complete();
            if (result)
                return Ok("Book Borrowed Successfully");
            else
                return BadRequest("Book not available or user not found");
        }

        [Authorize(Roles = "User,Admin")]
        [HttpPost("ReturnBook")]
        public IActionResult ReturnBooks(int BookId, string UserId)
        {
            var result = _unitOfWork.Books.ReturnBook(BookId, UserId);
            _unitOfWork.Complete();
            if (result)
                return Ok("Book Returned Succefully");
            else
                return BadRequest("Book not available or user not found");
        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet("GetByName")]
        public IActionResult GetByName()
        {
            var authors = _unitOfWork.Books.Find(b => b.Title == "NewBook", new[] { "Author" });
            return Ok(authors);
        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet("GetAllWithAuthors")]
        public IActionResult GetAllWithAuthors()
        {
            var authors = _unitOfWork.Books.FindAll(b => b.Title.Contains("NewBook"), new[] { "Author" });
            return Ok(authors);
        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet("GetOrdered")]
        public IActionResult GetOrdered()
        {
            var authors = _unitOfWork.Books.FindAll(b => b.Title.Contains("NewBook"), null, null, b => b.Id, OrderBy.Descending);
            return Ok(authors);
        }

    }
}
