using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class AssetReportDTO
    {
        public int AssetReportId { get; set; }
        public DateTime ReportDate { get; set; }
        public string Description { get; set; }
    }
}
