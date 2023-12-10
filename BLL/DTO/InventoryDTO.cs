using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class InventoryDTO
    {
        public int InventoryId { get; set; }
        public string AssetType { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal CurrentValue { get; set; }
        public decimal DepreciationRate { get; set; }
    }
}
