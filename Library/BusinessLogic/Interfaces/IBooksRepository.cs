using System.Collections.Generic;
using System.Web.Security;
using Domain.Entities;

namespace BusinessLogic.Interfaces
{
   public interface IBooksRepository
    {
        IEnumerable<Book> GetBook();
        Book GetBookByTitle(string Title);
        Book GetBookByISBN(string ISBN);
        Book GetBookByAuthor(string Author);

        void CreateBook(string Title, int AuthorId, string DisciplineId, int NumberOfPages,
                       int NumberOfCopies, string Location, string ISBN);

        void SaveBook(Book book);
        void DeleteBook(Book book);
    }
}
