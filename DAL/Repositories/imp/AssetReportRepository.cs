using DAL.EF;
using DAL.Entities;
using DAL.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.imp
{
    public class AssetReportRepository : BaseRepository<AssetReport>, IAssetReportRepository
    {
        internal AssetReportRepository(MyContext context) : base(context)
        {
        }
    }
}
