using E_Library.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Library.Patterns.Iterators
{
    public class LoanCollection
    {
        private readonly IBookManagement _bookManagement;
        private List<Book> _books = new List<Book>();
        public LoanCollection(IBookManagement bookManagement)
        {
            _bookManagement = bookManagement;
        }

        public LoanIterator GetLoanIterator()
        {
            _books = _bookManagement.GetAllBooks().Where(x=>x.BorrowedByUserId > 0).ToList();
            return new LoanIterator(_books);
        }
    }
}
