using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.Constants;
using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models;

namespace RepositoryPatternWithUOW.Api.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetById()
        {
            var authors = _unitOfWork.Books.GetById(1);
            return Ok(authors);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var authors = _unitOfWork.Books.GetAll();
            return Ok(authors);
        }

        [HttpGet("GetByName")]
        public IActionResult GetByName()
        {
            var authors = _unitOfWork.Books.Find(b => b.Title == "NewBook", new[] { "Author" });
            return Ok(authors);
        }

        [HttpGet("GetAllWithAuthors")]
        public IActionResult GetAllWithAuthors()
        {
            var authors = _unitOfWork.Books.FindAll(b => b.Title.Contains("NewBook"), new[] { "Author" });
            return Ok(authors);
        }

        [HttpGet("GetOrdered")]
        public IActionResult GetOrdered()
        {
            var authors = _unitOfWork.Books.FindAll(b => b.Title.Contains("NewBook"),null,null,b=>b.Id,OrderBy.Descending);
            return Ok(authors);
        }

        [HttpPost("AddOne")]
        public IActionResult AddOne()
        {
            var authors = _unitOfWork.Books.Add(new Book { Title = "Test 4",AuthorId=1});
            _unitOfWork.Complete();
            return Ok(authors);
        }
    }
}
