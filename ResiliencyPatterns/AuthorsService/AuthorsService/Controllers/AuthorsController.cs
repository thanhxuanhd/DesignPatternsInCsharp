using Microsoft.AspNetCore.Mvc;
using Monolith.Data;
using Monolith.Models;
using System.Collections.Generic;

namespace Monolith.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly Repository _repository;

        public AuthorsController(Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Author> Get() => _repository.GetAuthors();
    }
}
