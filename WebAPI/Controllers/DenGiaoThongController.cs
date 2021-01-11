using DataRepository;
using PTUDFinalProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class DenGiaoThongController : ApiController
    {
        // GET: api/DenGiaoThong
        public IEnumerable<DenGiaoThong> Get()
        {
            GTVTContext context = new GTVTContext();
            var lstDenGiaoThong = context.DenGiaoThongs.ToList();
            return lstDenGiaoThong;

        }

        // GET: api/DenGiaoThong/5
        public DenGiaoThong Get(int id)
        {
            GTVTContext context = new GTVTContext();
            var DenGiaoThong = context.DenGiaoThongs
                     .Where(b => b.Id == id)
                     .FirstOrDefault();
            return DenGiaoThong;
        }

        // POST: api/DenGiaoThong
        public IHttpActionResult Post(DenGiaoThong denGiaoThong)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (var ctx = new GTVTContext())
            {
                ctx.DenGiaoThongs.Add(new DenGiaoThong()
                {
                    Do = denGiaoThong.Do,
                    Xanh = denGiaoThong.Xanh,
                    Vang = denGiaoThong.Vang,
                    TrangThai = denGiaoThong.TrangThai,
                    KhuVuc_Id = denGiaoThong.KhuVuc_Id
                });
                //ctx.DenGiaoThongs.Add(denGiaoThong);
                ctx.SaveChanges();
            }
            return Ok();


        }

        // PUT: api/DenGiaoThong/5
        public IHttpActionResult Put(DenGiaoThong denGiaoThong)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new GTVTContext())
            {
                var existingDenGiaoThong = ctx.DenGiaoThongs.Where(s => s.Id == denGiaoThong.Id)
                                                        .FirstOrDefault<DenGiaoThong>();

                if (existingDenGiaoThong != null)
                {
                    existingDenGiaoThong.Do = denGiaoThong.Do;
                    existingDenGiaoThong.Vang = denGiaoThong.Xanh;
                    existingDenGiaoThong.Xanh = denGiaoThong.Xanh;
                    existingDenGiaoThong.TrangThai = denGiaoThong.TrangThai;
                    existingDenGiaoThong.KhuVuc_Id = denGiaoThong.KhuVuc_Id;
                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }

        // DELETE: api/DenGiaoThong/5
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid student id");

            using (var ctx = new GTVTContext())
            {
                var DenGiaoThong = ctx.DenGiaoThongs
                    .Where(s => s.Id == id)
                    .FirstOrDefault();

                ctx.Entry(DenGiaoThong).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }

            return Ok();
        }

    }
}
