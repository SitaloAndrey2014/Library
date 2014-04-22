using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set;}
        public int UserId { get; set; }
        public DateTime DateCreation { get; set;}
        public DateTime DeteExecution { get; set;}
        public string OrderStatus { get; set;}
        public int IdBook { get; set;}
        public bool ReturnBooks { get; set;}
    }
}
