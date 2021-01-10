using DataRepository;
using DataRepository.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ChuxeController : ApiController
    {

        // GET: api/Chuxe
        public IEnumerable<Chuxe> Get()
        {
            GTVTContext context = new GTVTContext();
            var lstChuxe = context.Chuxes.ToList();
            return lstChuxe;
        }

        // GET: api/Chuxe/5
        public IEnumerable<Chuxe> Get(int Id)
        {
            GTVTContext context = new GTVTContext();

            //var cmdText = "sp_xemchuxe_theoid @Id = @id_param";
            //var sqlParams = new[]{
            //new SqlParameter("id_param", Id) };
            //var lstChuxe = context.Database.SqlQuery<Chuxe>(cmdText, sqlParams).ToList();
            //return lstChuxe;
            var lstChuxe = context.Chuxes
                       .Where(a => a.ChuxeId == Id)
                       .Include(a => a.Xes).Include(a => a.ChuxevaBanglais)
                       .ToList();

            return lstChuxe;
        }

        // POST: api/Chuxe
        public HttpResponseMessage Post([FromBody] Chuxe chuxe)
        {
            try
            {
                using (GTVTContext context = new GTVTContext())
                {
                    context.Chuxes.Add(chuxe);
                    context.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, chuxe);
                    message.Headers.Location = new Uri(Request.RequestUri +
                        chuxe.ChuxeId.ToString());

                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT: api/Chuxe/5
        public HttpResponseMessage Put(int id, [FromBody] Chuxe chuxe)
        {
            try
            {
                using (GTVTContext context = new GTVTContext())
                {
                    var entity = context.Chuxes.FirstOrDefault(e => e.ChuxeId == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Chu xe voi Id " + id.ToString() + " khong co de sua");
                    }
                    else
                    {
                        entity.CMND = chuxe.CMND;
                        entity.HoTen = chuxe.HoTen;
                        entity.DiaChi = chuxe.DiaChi;
                        entity.GioiTinh = chuxe.GioiTinh;
                        entity.NamSinh = chuxe.NamSinh;
                        context.SaveChanges();

                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE: api/Chuxe/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (GTVTContext context = new GTVTContext())
                {
                    var entity = context.Chuxes.FirstOrDefault(e => e.ChuxeId == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Chu xe voi Id = " + id.ToString() + " khong co de xoa");
                    }
                    else
                    {
                        context.Chuxes.Remove(entity);
                        context.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //api/Chuxe/4/1
        [HttpGet]
        [Route("api/Chuxe/{ChuxeId}/{XeId}")]
        public void InsertChuxeXe(int ChuxeId, int XeId)
        {
            using (GTVTContext context = new GTVTContext())
            {
                Chuxe chuxe = new Chuxe { ChuxeId = ChuxeId };
                context.Chuxes.Add(chuxe);
                context.Chuxes.Attach(chuxe);

                Xe xe = new Xe { XeId = XeId };
                context.Xes.Add(xe);
                context.Xes.Attach(xe);

                chuxe.Xes = new List<Xe>();
                chuxe.Xes.Add(xe);
                context.SaveChanges();


            }
        }

        //api/ChuxeBanglai/4/1
        [HttpGet]
        [Route("api/ChuxeBanglai/{ChuxeId}/{BanglaiId}")]
        public void InsertChuxeBanglai(int ChuxeId, int BanglaiId)
        {
            using (GTVTContext context = new GTVTContext())
            {
                var chuxe = new Chuxe { ChuxeId = ChuxeId };
                //    context.Chuxes.Add(chuxe);
                //    context.Chuxes.Attach(chuxe);

                var banglai = new Banglai { BanglaiId = BanglaiId };
                //    context.Banglais.Add(banglai);
                //    context.Banglais.Attach(banglai);
                var ChuxeBanglai = new ChuXevaBangLai
                {
                    ChuxeId = chuxe.ChuxeId,
                    BanglaiId = banglai.BanglaiId
                };

                context.ChuXevaBangLais.Add(ChuxeBanglai);
                context.SaveChanges();

                //    chuxe.

                //context.SaveChanges();
                //GTVTContext context = new GTVTContext();
                //var cmdText = "sp_ThemTaixeBanglai @ChuxeId, @BanglaiId";
                //var sqlParams = new[]{
                //new SqlParameter("ChuxeId", ChuxeId),
                //new SqlParameter("BanglaiId", BanglaiId)};
                //context.Database.SqlQuery<ChuXevaBangLai>(cmdText, sqlParams);
                ////return lstChuxe;

            }
        }


    }
}
