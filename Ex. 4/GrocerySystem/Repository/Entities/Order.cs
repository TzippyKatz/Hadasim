using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

namespace Repository.Entities
{
    public class Order
    {
        [Key] // מגדיר שזה מפתח ראשי
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // קובע שהמזהה יהיה אוטומטי
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Supplier")]
        public int SupplietId { get; set; }
        public States Status { get; set; }
        [ForeignKey("Merchandise")]
        public int MerchandiseId { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
    }
}
