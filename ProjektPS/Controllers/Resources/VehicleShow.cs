using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektPS.Controllers.Resources
{
    public class VehicleShow
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsRegistered { get; set; }

        public string Image { get; set; }

        [Required]
        public ContactResource Contact { get; set; }

        public ICollection<string> Features { get; set; }

        public int Counter { get; set; }

        public string Description { get; set; }

        public string LastUpdate { get; set; }

        public VehicleShow()
        {
            Features = new Collection<string>();
        }
    }
}
