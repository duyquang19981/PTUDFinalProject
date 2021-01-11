using DataRepository;
using DataRepository.Models;
using PTUDFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTUDFinalProject
{
    public class GTVTContext : DbContext
    {
        public GTVTContext() : base("GTVTConnection")
        {

        }

        public DbSet<DenGiaoThong> DenGiaoThongs { get; set; }
        public DbSet<KhuVuc> KhuVucs { get; set; }
        public DbSet<Duong> Duongs { get; set; }
        public DbSet<TinhTrang> TinhTrangs { get; set; }
        public DbSet<TinhTrangDuong> TinhTrangDuongs { get; set; }

    }
}
