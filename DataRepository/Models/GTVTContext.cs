using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChucNang10
{
    public class GTVTContext: System.Data.Entity.DbContext
    {
        public GTVTContext() : base("name=GTVTConnection")
        {
        
        }

        public virtual DbSet<Chuxe> Chuxes { get; set; }
        public virtual DbSet<Xe> Xes { get; set; }
        public virtual DbSet<LuatGiaoThong> LuatGiaoThongs { get; set; }

    }
}
