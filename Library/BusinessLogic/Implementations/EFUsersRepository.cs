using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Security;
using BusinessLogic.Interfaces;
using Domain;
using Domain.Entities;

namespace BusinessLogic.Implementations
{
   public class EFUsersRepository:IUsersRepository
   {
       private EFDbContext context;
       public EFUsersRepository(EFDbContext context)
       {
           this.context = context;
       }

       public string GetUserNameByEmail(string email)
       {
           User user = context.Users.FirstOrDefault(x => x.Email == email);
           return user != null ? user.UserName : "";
       }

       public MembershipUser GetMembershipBookByName(string userName)
       {
           User user = context.Users.FirstOrDefault(x => x.UserName == userName);
           if (user != null)
           {
               return new MembershipUser("CustomMembershipProvider",
                  user.UserName,
                   user.Id,
                   user.Email,
                   "",
                   null,
                   true,
                   false,
                   user.CreateDate,
                   DateTime.Now,
                   DateTime.Now,
                   DateTime.Now,
                   DateTime.Now);
           }
           return null;
       }

       public void CreateUser(string userName, string password, string email, string firstName, string lastName, string middleName, string numberstudent)
        {
            User user = new User
                            {
                                UserName = userName,
                                Email = email,
                                Password = password,
                                CreateDate = DateTime.Now,
                                FirstName = firstName,
                                LastName = lastName,
                                MiddleName = middleName,
                                NumberStudent = numberstudent

                            };
            SaveUser(user);
        }

        public bool ValidateUser(string userName, string password)
        {
            User user = context.Users.FirstOrDefault(x => x.UserName == userName);
            if (user != null && user.Password == password)
                return true;
            return false;
        }

        public void SaveUser(User user)
        {
            if (user.Id == 0)
                context.Users.Add(user);
            else
            {
                context.Entry(user).State=EntityState.Modified;
            }
            context.SaveChanges();

        }
    }
}
