using DataAccess.DBContext;
using DataAccess.Entity;
using DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<DemoEmailListsDbSet> _logger;

        public DemoEmailListsDbSet(TaskmatesDbContext dbContext, ILogger<DemoEmailListsDbSet> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<List<DemoEmailList>?>? GetAllAsync()
        {
            try
            {
                var list = await _dbContext.DemoEmailLists.ToListAsync();

                if (list.Count == 0)
                {
                    _logger.LogInformation("No emails found");
                    return null;
                }

                return list;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }
    }
}
