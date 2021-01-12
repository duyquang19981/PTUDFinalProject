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

        // GET: api/BaoCao/5
        public IEnumerable<BaoCao> Get(int id)
        {
            GTVTContext context = new GTVTContext();
            var listReport = context.BaoCaos.Where(x => x.NguoiViPham == id).Include(b => b.ViPhamLuatGTs).ToList();
            return listReport;
        }

        // POST: api/BaoCao
        //[HttpPost]
        public IHttpActionResult Post(BaoCao bc, List<ViPhamLuatGT> dsViPham)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (GTVTContext ctx = new GTVTContext())
            {
                var baocao = bc;
                bc.ViPhamLuatGTs = dsViPham;

                ctx.BaoCaos.Add(baocao);
                ctx.SaveChanges();
            }
            return Ok();
        }
        //public HttpResponseMessage Post([FromBody]BaoCao bcao)
        //{
        //    try
        //    {
        //        using (GTVTContext gTVTContext = new GTVTContext())
        //        {
        //            gTVTContext.BaoCaos.Add(bcao);
        //            gTVTContext.SaveChanges();
        //            var message = Request.CreateResponse(HttpStatusCode.Created, bcao);
        //            message.Headers.Location = new Uri(Request.RequestUri + bcao.Id.ToString());
        //            return message;
        //        }    
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //}

        // PUT: api/BaoCao/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BaoCao/5
        public void Delete(int id)
        {
        }
    }
}
