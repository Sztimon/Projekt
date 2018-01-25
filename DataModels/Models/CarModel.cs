using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModels.Models
{
    [Table("CarModels")]
    public class CarModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Make Make { get; set; }

        public int MakeId { get; set; }
    }
}
