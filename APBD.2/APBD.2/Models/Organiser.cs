using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD._2.Models
{
    public class Organiser
    {
        public int IdOrganiser { get; set; }

        public string Name { get; set; }

        public ICollection<EventOrganiser> EventOrganisers { get; set; }
    }
}
