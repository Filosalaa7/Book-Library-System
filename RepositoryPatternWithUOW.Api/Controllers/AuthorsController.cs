using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models;

namespace RepositoryPatternWithUOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorsController(IUnitOfWork unitOfWork)
        {
            
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetById()
        {
            var authors = _unitOfWork.Authors.GetById(1);
            return Ok(authors);
        }

        [HttpGet("GetbyIdAsync")]
        public async Task<IActionResult> GetByIdAsync()
        {
            var authors = await _unitOfWork.Authors.GetByIdAsync(1);
            return Ok(authors);
        }
    }
}
