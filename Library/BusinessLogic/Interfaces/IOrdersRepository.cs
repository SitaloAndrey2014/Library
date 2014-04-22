using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;

namespace BusinessLogic.Interfaces
{
   public interface IOrdersRepository
    {
       IEnumerable<Order> GetOrder();
       Order GetOrderForUser(int IdUser);
       Order GetOrderByReturnBooks(bool ReturnBooks);
       void AddOrder(int UserId , DateTime DateCreation, DateTime DeteExecution ,string OrderStatus,
           int IdBook, bool ReturnBooks);
       void DeleteOrder(Order order);
    }
}
