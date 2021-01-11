using DataRepository;
using PTUDFinalProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace WebAPI.Controllers
{
    public class BaoCaoController : ApiController
    {
        //GET: api/BaoCao
        public IEnumerable<BaoCao> Get()
        {
            GTVTContext context = new GTVTContext();
            var listReport = context.BaoCaos.Include(b => b.ViPhamLuatGTs).ToList();
            return listReport;
        }

        //GET: api/BaoCao/5
        public IEnumerable<BaoCao> Get(int id)
        {
            GTVTContext context = new GTVTContext();
            var listReport = context.BaoCaos.Where(x => x.NguoiViPham == id).Include(b => b.ViPhamLuatGTs).ToList();
            return listReport;
        }


        //Xem chi tiet cac loi vi pham cua Bao cao
        // GET: api/BaoCao/5/details
        [Route("api/{idBaoCao}/details")]
        [HttpGet]
        public IEnumerable<LuatGiaoThong> GetDSViPham(int idBaoCao)
        {
            GTVTContext context = new GTVTContext();
            var listLuatViPham = (from l in context.LuatGiaoThongs
                                  join vp in context.ViPhamLuatGTs on l.Id equals vp.Id_LuatGiaoThong
                                  where vp.Id_BaoCao == idBaoCao
                                  select l
                                  ).ToList();

            return listLuatViPham;
        }


        // POST: api/BaoCao
        //[HttpPost]
        public IHttpActionResult Post(BaoCao baoCao)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (var ctx = new GTVTContext())
            {
                ctx.BaoCaos.Add(new BaoCao()
                {
                    NguoiViPham = baoCao.NguoiViPham,
                    DiaDiemPhat = baoCao.DiaDiemPhat,
                    ThoiGianLap = baoCao.ThoiGianLap,
                    TienPhat = baoCao.TienPhat,
                    TinhTrangNopPhat = "Chua"
                });
                ctx.SaveChanges();
            }
            return Ok();
        }

        // Nho lam them chi tiet cac vi pham vao moi bao cao

        // PUT: api/BaoCao/5
        public IHttpActionResult Put(int id, BaoCao baoCao)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new GTVTContext())
            {
                var oldBaoCao = ctx.BaoCaos.Where(s => s.Id == id)
                                                        .FirstOrDefault<BaoCao>();

                if (oldBaoCao != null)
                {
                    oldBaoCao.NguoiViPham = baoCao.NguoiViPham;
                    oldBaoCao.DiaDiemPhat = baoCao.DiaDiemPhat;
                    oldBaoCao.ThoiGianLap = baoCao.ThoiGianLap;
                    oldBaoCao.TienPhat = baoCao.TienPhat;
                    oldBaoCao.TinhTrangNopPhat = baoCao.TinhTrangNopPhat;
                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();
        }


        // DELETE: api/BaoCao/5
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid student id");

            using (var ctx = new GTVTContext())
            {
                var deleteBaoCao = ctx.BaoCaos
                    .Where(s => s.Id == id)
                    .FirstOrDefault();

                ctx.Entry(deleteBaoCao).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }

            return Ok();
        }
    }
}
