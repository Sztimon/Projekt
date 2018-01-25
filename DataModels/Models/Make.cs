using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.IO;


namespace DataModels.Models
{
    public class Make
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public  ICollection<CarModel> CarModels { get; set; }

        public Make()
        {
            CarModels = new Collection<CarModel>();
        }
    }
}
