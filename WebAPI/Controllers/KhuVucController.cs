using PTUDFinalProject;
using PTUDFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class KhuVucController : ApiController
    {
        // GET: api/KhuVuc
        public IEnumerable<KhuVuc> Get()
        {
            GTVTContext context = new GTVTContext();
            var lstKhuVuc = context.KhuVucs.ToList();
            return lstKhuVuc;

        }

        // GET: api/KhuVuc/5
        public KhuVuc Get(int id)
        {
            GTVTContext context = new GTVTContext();
            var KhuVuc = context.KhuVucs
                     .Where(b => b.Id == id)
                     .FirstOrDefault();
            return KhuVuc;
        }

        // POST: api/KhuVuc
        public IHttpActionResult Post(KhuVuc khuvuc)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (var ctx = new GTVTContext())
            {
                ctx.KhuVucs.Add(new KhuVuc()
                {
                    TenKhuVuc = khuvuc.TenKhuVuc,
                   
                });
                //ctx.KhuVucs.Add(khuvuc);
                ctx.SaveChanges();
            }
            return Ok();


        }

        // PUT: api/KhuVuc/5
        public IHttpActionResult Put(KhuVuc khuVuc)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new GTVTContext())
            {
                var existingKhuVuc = ctx.KhuVucs.Where(s => s.Id == khuVuc.Id)
                                                        .FirstOrDefault<KhuVuc>();

                if (existingKhuVuc != null)
                {
                    existingKhuVuc.TenKhuVuc = khuVuc.TenKhuVuc;
                   
                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();
        }

        // DELETE: api/KhuVuc/5
        //public IHttpActionResult Delete(int id)
        //{
        //    if (id <= 0)
        //        return BadRequest("Not a valid student id");

        //    using (var ctx = new GTVTContext())
        //    {
        //        var KhuVuc = ctx.KhuVucs
        //            .Where(s => s.Id == id)
        //            .FirstOrDefault();

        //        ctx.Entry(KhuVuc).State = System.Data.Entity.EntityState.Deleted;
        //        ctx.SaveChanges();
        //    }

        //    return Ok();
        //}
    }
}
