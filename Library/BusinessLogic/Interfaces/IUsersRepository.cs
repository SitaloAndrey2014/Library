using System.Web.Security;
using Domain.Entities;

namespace BusinessLogic.Interfaces
{
    public interface IUsersRepository
    {
        string GetUserNameByEmail(string email);
        MembershipUser GetMembershipBookByName(string userName);
        void CreateUser(string userName, string password, string email, string firstName, string lastName,
                        string middleName, string numberstudent);

        bool ValidateUser(string userName, string password);
        void SaveUser(User user);

    }
}
