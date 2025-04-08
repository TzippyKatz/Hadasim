using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum States
{
    InProcess,
    Completed,
    Pending
}

namespace Service.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SupplietId { get; set; }
        public States Status { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
    }
}
