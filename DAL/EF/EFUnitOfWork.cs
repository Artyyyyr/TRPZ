using DAL.Repositories.imp;
using DAL.Repositories;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly MyContext db;
        private BuildingRepository buildingRepository;
        private FurnitureRepository furnitureRepository;
        private DepartmentRepository departmentRepository;
        private InventoryRepository inventoryRepository;
        private AssetReportRepository assetReportRepository;

        public EFUnitOfWork(DbContextOptions options)
        {
            db = new MyContext(options);
        }

        public IBuildingRepository Buildings
        {
            get
            {
                if (buildingRepository == null)
                    buildingRepository = new BuildingRepository(db);
                return buildingRepository;
            }
        }

        public IFurnitureRepository Furnitures
        {
            get
            {
                if (furnitureRepository == null)
                    furnitureRepository = new FurnitureRepository(db);
                return furnitureRepository;
            }
        }

        public IDepartmentRepository Departments
        {
            get
            {
                if (departmentRepository == null)
                    departmentRepository = new DepartmentRepository(db);
                return departmentRepository;
            }
        }

        public IInventoryRepository Inventories
        {
            get
            {
                if (inventoryRepository == null)
                    inventoryRepository = new InventoryRepository(db);
                return inventoryRepository;
            }
        }

        public IAssetReportRepository AssetReports
        {
            get
            {
                if (assetReportRepository == null)
                    assetReportRepository = new AssetReportRepository(db);
                return assetReportRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }

                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
