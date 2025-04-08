using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository.Entities
{
    //המייל ייחודי למשתמש
    [Index(nameof(Email), IsUnique = true)]
    public class Supplier
    {
        [Key] // מגדיר שזה מפתח ראשי
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // קובע שהמזהה יהיה אוטומטי
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string RepresentativeName { get; set; }
        public string Phone { get; set; }
        [Required] //שדה חובה
        [EmailAddress] //תקינות למייל
        public string Email { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }

        public ICollection<SupplierMerchandise> SupplierMerchandises { get; set; }
    }
}
