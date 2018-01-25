using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektPS.Controllers.Resources
{
    public class MakeResource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<CarModelResource> CarModels { get; set; }

        public MakeResource()
        {
            CarModels = new Collection<CarModelResource>();
        }
    }
}
