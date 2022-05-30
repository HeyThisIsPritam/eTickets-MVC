using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Actor : DetailProp
    {
        //RelationShips
        public List<Actor_Movie> Actor_Movies { get; set; }
    }
}
