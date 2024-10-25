using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface IDemoEmailListsDbSet
    {
        /// <summary>
        /// Get all data from the DemoEmailLists table
        /// </summary>
        /// <returns>The list of DemoEmailLists rows</returns>
        Task<List<DemoEmailList>?>? GetAllAsync();
    }
}
