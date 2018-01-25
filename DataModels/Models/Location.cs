using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModels.Models
{
    [Table("Locations")]
    public class Location
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Counter { get; set; }
        public Location() { }
        public Location(String name, int counter)
        {
            this.Name = name;
            this.Counter = counter;
        }
    }
}
