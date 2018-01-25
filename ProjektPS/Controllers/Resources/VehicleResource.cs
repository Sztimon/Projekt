using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektPS.Controllers.Resources
{
    public class VehicleResource
    {
        public int Id { get; set; }


        public int CarModelId { get; set; }
        public string Name { get; set; }

        public bool IsRegistered { get; set; }

        public string Image { get; set; }

        [Required]
        public ContactResource Contact { get; set; }

        public ICollection<int> Features { get; set; }


        public string Description { get; set; }


        public VehicleResource()
        {
            Features = new Collection<int>();
        }
        /*
        public int Id { get; set; }

        public int CarModelId { get; set; }

        public bool IsRegistered { get; set; }

        public string Image { get; set; }

        [Required]
        public ContactResource Contact { get; set; }

        public ICollection<int> Features { get; set; }

        public VehicleResource()
        {
            Features = new Collection<int>();
        }
        */
    }
}
