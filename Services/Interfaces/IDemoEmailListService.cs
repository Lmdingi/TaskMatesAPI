using Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IDemoEmailListService
    {
        /// <summary>
        /// Get all data from the DemoEmailLists table
        /// </summary>
        /// <returns>The list of DemoEmailLists rows</returns>
        Task<List<DemoEmailList>?>? GetAllAsync();
    }
}
