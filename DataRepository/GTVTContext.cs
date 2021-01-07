using DataRepository;
using PTUDFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTUDFinalProject
{
    public class GTVTContext:DbContext
    {
        public GTVTContext() : base("GTVTConnection")
        {

        }

        public DbSet<DenGiaoThong> DenGiaoThongs { get; set; }
        public DbSet<KhuVuc> KhuVucs{ get; set; }

    }
    }
