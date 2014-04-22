using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using BusinessLogic.Interfaces;
using Domain.Entities;
using Domain;

namespace BusinessLogic.Implementations
{
   public class EFOrdersRepository:IOrdersRepository
   {
       private EFDbContext context;
       public EFOrdersRepository(EFDbContext context)
       {
           this.context = context;
       }
       public IEnumerable<Order> GetOrder()
       {
           return context.Orders;
       }

       public Order GetOrderForUser(int IdUser)
       {
           return context.Orders.FirstOrDefault(x => x.UserId == IdUser);
       }

       public Order GetOrderByReturnBooks(bool ReturnBooks)
       {
           return context.Orders.FirstOrDefault(x => x.ReturnBooks == ReturnBooks);
       }

       public void AddOrder(int UserId, DateTime DateCreation, 
                            DateTime DeteExecution, string OrderStatus,
                            int IdBook, bool ReturnBooks)
       {
           Order order=new Order
                           {
                               UserId = UserId,
                               DateCreation = DateTime.Now,
                               DeteExecution = DateTime.Now,
                               IdBook = IdBook,
                               OrderStatus = OrderStatus,
                               ReturnBooks = ReturnBooks
                           };
           context.Orders.Add(order);
           context.SaveChanges();
       }

       public void DeleteOrder(Order order)
       {
           context.Orders.Remove(order);
           context.SaveChanges();
       }
    }
}
