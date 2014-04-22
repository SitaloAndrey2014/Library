using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Interfaces;
using Domain;
using Domain.Entities;

namespace BusinessLogic.Implementations
{
    public class EFAuthorsRepository:IAuthorRepository
    {
        private EFDbContext contex;
        public EFAuthorsRepository(EFDbContext context)
        {
            context = context;
        }
        public IEnumerable<Author> GetAuthor()
        {
            return contex.Authors;
        }

        public void AddAuthor(string FirstName, string LastName, string MiddleName)
        {
            Author author = new Author
                                {
                                    FirstName = FirstName,
                                    LastName = LastName,
                                    MiddleName = MiddleName
                                };
            contex.Authors.Add(author);
            contex.SaveChanges();
        }
    }
}
