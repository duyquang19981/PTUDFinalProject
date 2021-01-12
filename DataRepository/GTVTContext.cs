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
        public virtual DbSet<Chuxe> Chuxes { get; set; }
        public virtual DbSet<Xe> Xes { get; set; }
        public virtual DbSet<Banglai> Banglais { get; set; }
        public DbSet<ChuXevaBangLai> ChuXevaBangLais { get; set; }
        public DbSet<Duong> Duongs { get; set; }
        public DbSet<TinhTrang> TinhTrangs { get; set; }
        public DbSet<TinhTrangDuong> TinhTrangDuongs { get; set; }

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

            //huy
            modelBuilder.Entity<Xe>()
            .HasRequired<Chuxe>(s => s.Chuxe)
            .WithMany(g => g.Xes)
            .HasForeignKey<int>(s => s.ChuxeId);


            modelBuilder.Entity<ChuXevaBangLai>()
                .HasKey(sc => new { sc.ChuxeId, sc.BanglaiId });
            //---huy
            //Nhu
            
            modelBuilder.Entity<TinhTrangDuong>()
            .HasRequired<TinhTrang>(s => s.TinhTrang)
            .WithMany(g => g.TinhTrangDuongs)
            .HasForeignKey<int?>(s => s.TinhTrang_Id);
            // Nhu
            modelBuilder.Entity<TinhTrangDuong>()
           .HasRequired<Duong>(s => s.Duong)
           .WithMany(g => g.TinhTrangDuongs)
           .HasForeignKey<int?>(s => s.Duong_Id);
            
        }
    }
}
