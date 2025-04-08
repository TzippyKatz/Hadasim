using Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto
{
    public class SupplierDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string RepresentativeName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }

        //public ICollection<SupplierMerchandise> SupplierMerchandises { get; set; }
    }
}
