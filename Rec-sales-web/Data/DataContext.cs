using Microsoft.EntityFrameworkCore;
using Rec_sales_web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rec_sales_web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<NotifyEntity> Notifies { get; set; }
    }
}
