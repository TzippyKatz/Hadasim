using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class SupplierMerchandise
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        [ForeignKey("Merchandise")]
        public int MerchandiseId { get; set; }
        public virtual Merchandise Merchandise { get; set; }
        public int Quantity { get; set; }
    }
}