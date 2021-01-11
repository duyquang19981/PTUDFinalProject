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
        public DbSet<DenGT_ThayDoi> DenGT_ThayDois { get; set; }
        public DbSet<NguoiQuanLyGT> NguoiQuanLyGTs { get; set; }
        public DbSet<BaoCao> BaoCaos { get; set; }
        public DbSet<LuatGiaoThong> LuatGiaoThongs { get; set; }
        public DbSet<ViPhamLuatGT> ViPhamLuatGTs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<DenGiaoThong>()
                .HasRequired<KhuVuc>(s => s.KhuVuc)
                .WithMany(g => g.DenGiaoThongs)
                .HasForeignKey<int?>(s => s.KhuVuc_Id);

            modelBuilder.Entity<DenGT_ThayDoi>()
              .HasRequired<DenGiaoThong>(s => s.DenGiaoThong)
              .WithMany(g => g.DenGT_ThayDois)
              .HasForeignKey<int?>(s => s.DenGiaoThong_Id);
            modelBuilder.Entity<DenGT_ThayDoi>()
                .HasRequired<NguoiQuanLyGT>(s => s.NguoiQuanLyGT)
                .WithMany(g => g.DenGT_ThayDois)
                .HasForeignKey<int?>(s => s.NguoiQuanLyGT_Id);
            // khang
            // configures one-to-many relationship
            modelBuilder.Entity<ViPhamLuatGT>()
                .HasRequired<BaoCao>(s => s.BaoCao)
                .WithMany(g => g.ViPhamLuatGTs)
                .HasForeignKey<int>(s => s.Id_BaoCao);

            modelBuilder.Entity<ViPhamLuatGT>()
                .HasRequired<LuatGiaoThong>(s => s.LuatGiaoThong)
                .WithMany(g => g.ViPhamLuatGTs)
                .HasForeignKey<int>(s => s.Id_LuatGiaoThong);
            //---khang
        }
    }
}
