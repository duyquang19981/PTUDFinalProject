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
    public class DenGT_ThayDoiController : ApiController
    {
        // main git 
        // GET: api/DenGT_ThayDoi
        public IEnumerable<DenGT_ThayDoi> Get()
        {
            GTVTContext context = new GTVTContext();
            var lstDenGT_ThayDoi = context.DenGT_ThayDois.ToList();
            return lstDenGT_ThayDoi;

        }

        // GET: api/DenGT_ThayDoi/5
        public DenGT_ThayDoi Get(int id)
        {
            GTVTContext context = new GTVTContext();
            var DenGT_ThayDoi = context.DenGT_ThayDois
                     .Where(b => b.Id == id)
                     .FirstOrDefault();
            return DenGT_ThayDoi;
        }

        //POST: api/DenGT_ThayDoi
        public IHttpActionResult Post(DenGT_ThayDoi denGT_ThayDoi)
        {
            DateTime today = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (var ctx = new GTVTContext())
            {
                ctx.DenGT_ThayDois.Add(new DenGT_ThayDoi()
                {
                    ThoiDiemThayDoi = denGT_ThayDoi.ThoiDiemThayDoi,
                    ThoiGianDoi = denGT_ThayDoi.ThoiGianDoi,
                    Do_TD = denGT_ThayDoi.Do_TD,
                    Vang_TD = denGT_ThayDoi.Vang_TD,
                    Xanh_TD = denGT_ThayDoi.Xanh_TD,
                    TuDong = denGT_ThayDoi.TuDong,
                    ThoiGianThucHien = denGT_ThayDoi.ThoiGianThucHien,
                    DenGiaoThong_Id = denGT_ThayDoi.DenGiaoThong_Id,
                    NguoiQuanLyGT_Id = denGT_ThayDoi.NguoiQuanLyGT_Id,
                });
                //ctx.DenGT_ThayDois.Add(denGT_ThayDoi);
                ctx.SaveChanges();
            }
            return Ok();


        }

        // PUT: api/DenGT_ThayDoi/5
        public IHttpActionResult Put(int id, DenGT_ThayDoi denGT_ThayDoi)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new GTVTContext())
            {
                var existingDenGT_ThayDoi = ctx.DenGT_ThayDois.Where(s => s.Id == id)
                                                        .FirstOrDefault<DenGT_ThayDoi>();

                if (existingDenGT_ThayDoi != null)
                {
                    existingDenGT_ThayDoi.ThoiDiemThayDoi = denGT_ThayDoi.ThoiDiemThayDoi;
                    existingDenGT_ThayDoi.ThoiGianDoi = denGT_ThayDoi.ThoiGianDoi;
                    existingDenGT_ThayDoi.Do_TD = denGT_ThayDoi.Do_TD;
                    existingDenGT_ThayDoi.Vang_TD = denGT_ThayDoi.Vang_TD;
                    existingDenGT_ThayDoi.Xanh_TD = denGT_ThayDoi.Xanh_TD;
                    existingDenGT_ThayDoi.TuDong = denGT_ThayDoi.TuDong;
                   // existingDenGT_ThayDoi.DenGiaoThong_Id = denGT_ThayDoi.DenGiaoThong_Id;
                   // existingDenGT_ThayDoi.NguoiQuanLyGT_Id = denGT_ThayDoi.NguoiQuanLyGT_Id;
                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }

        // DELETE: api/DenGT_ThayDoi/5
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid student id");

            using (var ctx = new GTVTContext())
            {
                var DenGT_ThayDoi = ctx.DenGT_ThayDois
                    .Where(s => s.Id == id)
                    .FirstOrDefault();

                ctx.Entry(DenGT_ThayDoi).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }

            return Ok();
        }

    }
}
