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

        private IEnumerable<Book> _books { get; set; }

        public Repository()
        {
            _books = new[]
            {
                new Book
                {
                    BookId = 1,
                    AuthorId = 1,
                    Name = "The Fallen Shore",
                    NumberOfPages = 123
                },
                new Book
                {
                    BookId = 2,
                    AuthorId = 1,
                    Name = "Harmony of Joy",
                    NumberOfPages = 211
                },
                new Book
                {
                    BookId = 3,
                    AuthorId = 2,
                    Name = "Aliens vs Robots",
                    NumberOfPages = 345
                }
            };
        }

        public IEnumerable<Book> GetBooks()
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

            return _books;
        }
    }
}
