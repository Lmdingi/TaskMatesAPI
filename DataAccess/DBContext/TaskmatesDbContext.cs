using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DBContext
{
    public class TaskmatesDbContext : DbContext
    {
        public TaskmatesDbContext()
        {
        }

        public TaskmatesDbContext(DbContextOptions<TaskmatesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DemoEmailList> DemoEmailLists { get; set; }
    }
}
