using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Tarea3_DWB.NorthwindData;

namespace Tarea3_DWB.BackEnd
{
    public class OrderSC : BaseSC
    {
        public IQueryable<Order> GetOrderById(int orderID)
        {
            return GetAllOrders().Where(w => w.OrderId == orderID);
        }

        private IQueryable<Order> GetAllOrders()
        {
            return dbContext.Orders;
        }
    }
}
