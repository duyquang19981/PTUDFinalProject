using DataRepository;
using DataRepository.Models;
using PTUDFinalProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class NguoiQuanLyGTController : ApiController
    {
        // main git 
        // GET: api/NguoiQuanLyGT
        public IEnumerable<NguoiQuanLyGT> Get()
        {
            GTVTContext context = new GTVTContext();
            var lstNguoiQuanLyGT = context.NguoiQuanLyGTs.ToList();
            return lstNguoiQuanLyGT;

        }

        // GET: api/NguoiQuanLyGT/5
        public NguoiQuanLyGT Get(int id)
        {
            GTVTContext context = new GTVTContext();
            var NguoiQuanLyGT = context.NguoiQuanLyGTs
                     .Where(b => b.Id == id)
                     .FirstOrDefault();
            return NguoiQuanLyGT;
        }

        //POST: api/NguoiQuanLyGT
        public IHttpActionResult Post(NguoiQuanLyGT nguoiQuanLyGT)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (var ctx = new GTVTContext())
            {
                ctx.NguoiQuanLyGTs.Add(new NguoiQuanLyGT()
                {
                    Ten = nguoiQuanLyGT.Ten,
                    NgaySinh = nguoiQuanLyGT.NgaySinh,
                    Username = nguoiQuanLyGT.Username,
                    Password = nguoiQuanLyGT.Password,
                });
                //ctx.NguoiQuanLyGTs.Add(nguoiQuanLyGT);
                ctx.SaveChanges();
            }
            return Ok();


        }

        // PUT: api/NguoiQuanLyGT/5
        public IHttpActionResult Put(int id, NguoiQuanLyGT nguoiQuanLyGT)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new GTVTContext())
            {
                var existingNguoiQuanLyGT = ctx.NguoiQuanLyGTs.Where(s => s.Id == id)
                                                        .FirstOrDefault<NguoiQuanLyGT>();

                if (existingNguoiQuanLyGT != null)
                {
                    existingNguoiQuanLyGT.Ten = nguoiQuanLyGT.Ten;
                    existingNguoiQuanLyGT.NgaySinh = nguoiQuanLyGT.NgaySinh;
                    existingNguoiQuanLyGT.Username = nguoiQuanLyGT.Username;
                    existingNguoiQuanLyGT.Password = nguoiQuanLyGT.Password;
                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }

        // DELETE: api/NguoiQuanLyGT/5
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid student id");

            using (var ctx = new GTVTContext())
            {
                var NguoiQuanLyGT = ctx.NguoiQuanLyGTs
                    .Where(s => s.Id == id)
                    .FirstOrDefault();

                ctx.Entry(NguoiQuanLyGT).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }

            return Ok();
        }

    }
}
