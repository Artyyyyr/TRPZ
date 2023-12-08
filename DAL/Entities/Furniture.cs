using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Furniture
    {
        public int FurnitureId { get; set; }
        public string Type { get; set; }
        public string Material { get; set; }
        public string Condition { get; set; }
    }
}
