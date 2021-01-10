using DataRepository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository
{
    public class GTVTContext: System.Data.Entity.DbContext
    {
        public GTVTContext() : base("GTVTConnection")
        {

        }

        
        public virtual DbSet<Chuxe> Chuxes { get; set; }
        public virtual DbSet<Xe> Xes { get; set; }
        public virtual DbSet<Banglai> Banglais { get; set; }
    }
}
