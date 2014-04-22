using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Interfaces;

namespace BusinessLogic
{//Класс через который будет централизованно происходит обмен данными в приложеннии
    public class DatаManager
    {
        private IUsersRepository usersRepository;
        private IOrdersRepository OrdersRepository;
        private IBooksRepository booksRepository;
        private IAuthorRepository authorRepository;
        private PrimaryMembershipProvider provider;
        public DatаManager(IUsersRepository usersRepository, IOrdersRepository OrdersRepository, IBooksRepository booksRepository, IAuthorRepository authorRepository, PrimaryMembershipProvider provider)
        {
            this.usersRepository = usersRepository;
            this.OrdersRepository=OrdersRepository;
            this.booksRepository = booksRepository;
            this.authorRepository = authorRepository;
            this.provider = provider;
        }
        //возвращаяем наружу классу который требует для работы
        public IUsersRepository Users { get {return usersRepository;} }
        public IOrdersRepository Orders { get {return OrdersRepository;} }
        public IBooksRepository Books { get {return booksRepository;} }
        public IAuthorRepository Author{get { return authorRepository; }}
        public PrimaryMembershipProvider MembershipProvider { get { return provider; } }



    }
}
