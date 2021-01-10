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
        public DbSet<ChuXevaBangLai> ChuXevaBangLais { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<Xe>()
                .HasRequired<Chuxe>(s => s.Chuxe)
                .WithMany(g => g.Xes)
                .HasForeignKey<int>(s => s.ChuxeId);


            modelBuilder.Entity<ChuXevaBangLai>()
                .HasKey(sc => new { sc.ChuxeId, sc.BanglaiId });

            //modelBuilder.Entity<ChuXevaBangLai>()
            //    .HasRequired<Chuxe>(s => s.Chuxe)
            //    .WithMany(g => g.ChuXevaBangLais)
            //    .HasForeignKey<int>(s => s.ChuxeId);

            //modelBuilder.Entity<ChuXevaBangLai>()
            //    .HasRequired<Banglai>(s => s.Banglai)
            //    .WithMany(g => g.ChuXevaBangLais)
            //    .HasForeignKey<int>(s => s.BanglaiId);


        }
    }
}
