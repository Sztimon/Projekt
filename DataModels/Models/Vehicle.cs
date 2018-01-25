using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModels.Models
{
    [Table("Vehicles")]
    public class Vehicle
    {
        public int Id { get; set; }

        public int CarModelId { get; set; }

        public CarModel CarModel { get; set; }

        public bool IsRegistered { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        [Required]
        [StringLength(255)]
        public string ContactName { get; set; }

        [Required]
        [StringLength(255)]
        public string ContactPhone { get; set; }

        [StringLength(255)]
        public string ContactEmail { get; set; }

        public DateTime LastUpdate { get; set; }

        public int Counter { get; set; }

        public ICollection<VehicleFeature> Features { get; set; }

        public Vehicle()
        {
            Features = new Collection<VehicleFeature>();
        }
    }
}
