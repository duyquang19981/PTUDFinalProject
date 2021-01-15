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
    public class ViPhamController : ApiController
    {
        // GET: api/ViPham
        // GET: api/ViPham/5
   

        // PUT: api/ViPham/5
        [Route("api/BaoCao/{id_BaoCao}/ThemLuatViPham")]
        [HttpPost]
        public IHttpActionResult Post(ViPhamLuatGT viPham)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (var ctx = new GTVTContext())
            {
                ctx.ViPhamLuatGTs.Add(new ViPhamLuatGT()
                {
                    Id_BaoCao = viPham.Id_BaoCao,
                    Id_LuatGiaoThong = viPham.Id_LuatGiaoThong
                });
                ctx.SaveChanges();
            }
            return Ok();
        }

        // DELETE: api/ViPham/5
        public void Delete(int id)
        {
        }
    }
}
