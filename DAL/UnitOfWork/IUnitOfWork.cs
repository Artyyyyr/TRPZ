using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBuildingRepository Buildings { get; }
        IFurnitureRepository Furnitures { get; }
        IDepartmentRepository Departments { get; }
        IInventoryRepository Inventories { get; }
        IAssetReportRepository AssetReports { get; }

        void Save();
    }
}
