using Microsoft.AspNetCore.Mvc;
using Monolith.Data;
using Monolith.Models;
using System.Collections.Generic;

namespace Monolith.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly Repository _repository;

        public BooksController(Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Book> Get() => _repository.GetBooks();
    }
}
