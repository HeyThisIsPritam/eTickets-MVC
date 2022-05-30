using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Producer : DetailProp
    {
        // Relationships
        public List<Movie> Movies { get; set; }
    }
}
