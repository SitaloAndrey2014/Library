using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;

namespace BusinessLogic.Interfaces
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAuthor();
        void AddAuthor(string FirstName, string LastName, string MiddleName);
    }
}
