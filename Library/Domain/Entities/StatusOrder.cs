using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class StatusOrder
    {
        public List<string> statusOrder= new List<string>()
                                     {"выполнен",
                                      "в обработке",
                                      "ожидает"};
    }
}
