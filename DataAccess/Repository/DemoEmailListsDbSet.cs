using DataAccess.DBContext;
using DataAccess.Entity;
using DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class DemoEmailListsDbSet : IDemoEmailListsDbSet
    {
        private readonly TaskmatesDbContext _dbContext;

        public DemoEmailListsDbSet(TaskmatesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DemoEmailList>?>? GetAllAsync()
        {
            var list = await _dbContext.DemoEmailLists.ToListAsync();

            if (list.Count == 0)
            {
                return null;
            }

            return list;
        }
    }
}
