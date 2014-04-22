using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web.Security;
using BusinessLogic.Interfaces;
using Domain;
using Domain.Entities;

namespace BusinessLogic.Implementations
{
   public class EFBooksRepository:IBooksRepository
    {
       private EFDbContext context;
       public EFBooksRepository(EFDbContext context)
       {
           this.context = context;
       }
       public IEnumerable<Book> GetBook()
       {
           return context.Books;
       }

       public Book GetBookByTitle(string Title)
       {
          return context.Books.FirstOrDefault(x => x.Title == Title);
       }

       public Book GetBookByISBN(string ISBN)
       {
           return context.Books.FirstOrDefault(x => x.ISBN== ISBN);
       }

       public Book GetBookByAuthor(string Author)
       {
           Author author = context.Authors.FirstOrDefault(x => x.FirstName == Author);
           return context.Books.FirstOrDefault(x => x.AuthorId == author.AuthorId);
       }


       public void CreateBook(string Title, int AuthorId, string DisciplineId, int NumberOfPages, int NumberOfCopies, string Location, string ISBN)
       {
           Book book = new Book
                           {
                               AuthorId = AuthorId,
                               Title = Title,
                               DisciplineId = DisciplineId,
                               ISBN = ISBN,
                               Location = Location,
                               NumberOfCopies = NumberOfCopies,
                               NumberOfPages = NumberOfPages
                           };
           SaveBook(book);
       }

       public void SaveBook(Book book)
       {
           if (book.BookId == 0)
               context.Books.Add(book);
           else
           {
               context.Entry(book).State = EntityState.Modified;
           }
           context.SaveChanges();
       }

       public void DeleteBook(Book book)
       {
           context.Books.Remove(book);
           context.SaveChanges();
       }
    }
}
