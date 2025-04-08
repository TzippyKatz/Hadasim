using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto
{
    public class SupplierMerchandiseDto
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int MerchandiseId { get; set; }
        public int Quantity { get; set; }
    }
}
