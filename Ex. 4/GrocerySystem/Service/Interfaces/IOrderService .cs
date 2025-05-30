﻿using Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IOrderService: IService<OrderDto>
    {
        List<OrderDto> GetBySupplierId(int supplierId);
        List<OrderDto> GetPendingOrders();
    }
}
