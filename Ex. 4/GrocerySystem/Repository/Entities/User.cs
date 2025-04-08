using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Repository.Entities
{
    public class User
    {
        [Key] // מגדיר שזה מפתח ראשי
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // קובע שהמזהה יהיה אוטומטי
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
    }
}
