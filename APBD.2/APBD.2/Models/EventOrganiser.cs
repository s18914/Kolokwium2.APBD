using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;

namespace APBD._2.Models
{
    public class EventOrganiser
    {
        public int IdEvent { get; set; }
        public int IdOrganiser { get; set; }
        public Organiser Organiser { get; set; }
        public Event Event { get; set; }

    }
}