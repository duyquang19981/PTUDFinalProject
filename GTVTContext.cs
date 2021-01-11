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
        public DbSet<BaoCao> BaoCaos { get; set; }
        public DbSet<LuatGiaoThong> LuatGiaoThongs { get; set; }
        public DbSet<ViPhamLuatGT> ViPhamLuatGTs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<ViPhamLuatGT>()
                .HasRequired<BaoCao>(s => s.BaoCao)
                .WithMany(g => g.ViPhamLuatGTs)
                .HasForeignKey<int>(s => s.Id_BaoCao);

            modelBuilder.Entity<ViPhamLuatGT>()
                .HasRequired<LuatGiaoThong>(s => s.LuatGiaoThong)
                .WithMany(g => g.ViPhamLuatGTs)
                .HasForeignKey<int>(s => s.Id_LuatGiaoThong);
        }
    }

}
