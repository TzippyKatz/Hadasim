using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Merchandise
    {
        [Key] // מגדיר שזה מפתח ראשי
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // קובע שהמזהה יהיה אוטומטי
        public int Id { get; set; }
        public string Product_name { get; set; }
        public double Price { get; set; }
        public int MinQuantity { get; set; }

        public ICollection<SupplierMerchandise> SupplierMerchandises { get; set; }
    }
}