using DataRepository.Models;
using PTUDFinalProject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class TinhTrangDuongController : ApiController
    {
        // GET: api/TinhTrangDuong
        public IEnumerable<TinhTrangDuong> Get()
        {
            GTVTContext context = new GTVTContext();
            var lstTinhTrangDuong = context.TinhTrangDuongs.ToList();
            return lstTinhTrangDuong;

        }

        public TinhTrangDuong Get(int id)
        {
            GTVTContext context = new GTVTContext();
            var TinhTrangDuong = context.TinhTrangDuongs
                     .Where(b => b.Id == id)
                     .FirstOrDefault();
            return TinhTrangDuong;
        }

        // POST: api/TinhTrangDuong
        public IHttpActionResult Post(TinhTrangDuong tinhTrangDuong)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (var ctx = new GTVTContext())
            {
                ctx.TinhTrangDuongs.Add(new TinhTrangDuong()
                {
                    KhuVuc_Id= tinhTrangDuong.KhuVuc_Id,
                    TenDuong=tinhTrangDuong.TenDuong,
                    TrangThai=tinhTrangDuong.TrangThai                    
                });
                //ctx.TinhTrangDuongs.Add(tinhTrangDuong);
                ctx.SaveChanges();
            }
            return Ok();
        }

        // PUT: api/TinhTrangDuong/5
        public IHttpActionResult Put(int id, TinhTrangDuong tinhTrangDuong)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new GTVTContext())
            {
                var existingTinhTrangDuong = ctx.TinhTrangDuongs.Where(s => s.Id == id)
                                                        .FirstOrDefault<TinhTrangDuong>();

                if (existingTinhTrangDuong != null)
                {
                    existingTinhTrangDuong.KhuVuc_Id = tinhTrangDuong.KhuVuc_Id;
                    existingTinhTrangDuong.TenDuong = tinhTrangDuong.TenDuong;
                    existingTinhTrangDuong.TrangThai = tinhTrangDuong.TrangThai;
                        
                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }

        // DELETE: api/TinhTrangDuong/5
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid student id");

            using (var ctx = new GTVTContext())
            {
                var TinhTrangDuong = ctx.TinhTrangDuongs
                    .Where(s => s.Id == id)
                    .FirstOrDefault();

                ctx.Entry(TinhTrangDuong).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }

            return Ok();
        }
    }
}
