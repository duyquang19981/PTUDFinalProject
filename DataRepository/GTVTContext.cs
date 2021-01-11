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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
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

        }
    }
}
