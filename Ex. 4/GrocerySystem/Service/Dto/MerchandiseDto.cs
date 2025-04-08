using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto
{
    public class MerchandiseDto
    {
        public int Id { get; set; }
        public string Product_name { get; set; }
        public double Price { get; set; }
        public int MinQuantity { get; set; }

        //public ICollection<SupplierMerchandise> SupplierMerchandises { get; set; }
    }
}
