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
    public class FurnitureRepository : BaseRepository<Furniture>, IFurnitureRepository
    {
        internal FurnitureRepository(MyContext context) : base(context)
        {
        }
    }
}
