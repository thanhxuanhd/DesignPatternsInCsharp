using Monolith.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Monolith.Data
{
    public class Repository
    {
        private bool _shouldFail = true;
        private DateTime _startTime = DateTime.UtcNow;
        private IEnumerable<Author> _authors { get; set; }

        public Repository()
        {
            _authors = new[]
            {
                new Author
                {
                    AuthorId = 1,
                    Name = "John Doe",
                    Country = "Australia"
                },
                new Author
                {
                    AuthorId = 2,
                    Name = "Jane Smith",
                    Country = "United States"
                }
            };
        }

        public IEnumerable<Author> GetAuthors()
        {
            if (_shouldFail)
            {
                _shouldFail = false;
                throw new System.Exception("Oops!");
            }

            // Circuit Breaker  
            if (_startTime.AddMinutes(1) > DateTime.UtcNow)
            {
                Thread.Sleep(5000);
                throw new Exception("Timeout!");
            }

            return _authors;
        }
    }
}