﻿using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IOrderRepository: IRepository<Order>
    {
        List<Order> GetBySupplierId(int supplierId);
        List<Order> GetPendingOrders();
    }
}
