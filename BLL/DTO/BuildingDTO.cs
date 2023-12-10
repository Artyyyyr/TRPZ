using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class BuildingDTO
    {
        public int BuildingId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Area { get; set; }
        public int ConstructionYear { get; set; }
        public string Condition { get; set; }
    }
}
