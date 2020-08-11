using Microsoft.EntityFrameworkCore;
using RecSalesWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecSalesWeb.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<NotifyEntity> Notifies { get; set; }

    }
}
