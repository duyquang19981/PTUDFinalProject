using DataRepository;
using DataRepository.Models;
using PTUDFinalProject;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace WebAPI.Controllers
{
    public class BanglaiController : ApiController
    {
        // GET: api/Banglai
        public IEnumerable<Banglai> Get()
        {
            GTVTContext context = new GTVTContext();
            var lstBanglai = context.Banglais.ToList();
            return lstBanglai;
        }

        // GET: api/Banglai/5
        public IEnumerable<Banglai> Get(int id)
        {
            GTVTContext context = new GTVTContext();

            //var cmdText = "Exec sp_laybanglai_id @Id = @name_param";
            //var sqlParams = new[]{
            //new SqlParameter("name_param", id) };
            //var lstBanglai = context.Database.SqlQuery<Banglai>(cmdText, sqlParams).ToList();
            //return lstBanglai;

            var lstBanglai = context.Banglais
                      .Where(a => a.BanglaiId == id)
                      .ToList();

            return lstBanglai;
        }


        // POST: api/Banglai
        public HttpResponseMessage Post([FromBody] Banglai banglai)
        {
            try
            {
                using (GTVTContext context = new GTVTContext())
                {
                    context.Banglais.Add(banglai);
                    context.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, banglai);
                    message.Headers.Location = new Uri(Request.RequestUri +
                        banglai.BanglaiId.ToString());

                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT: api/Banglai/5
        public HttpResponseMessage Put(int id, [FromBody] Banglai banglai)
        {
            try
            {
                using (GTVTContext context = new GTVTContext())
                {
                    var entity = context.Banglais.FirstOrDefault(e => e.BanglaiId == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Bang lai voi Id " + id.ToString() + " khong co de sua");
                    }
                    else
                    {
                        entity.LoaiBang = banglai.LoaiBang;
                        entity.ThongTin = banglai.ThongTin;

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

        // DELETE: api/Banglai/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (GTVTContext context = new GTVTContext())
                {
                    var entity = context.Banglais.FirstOrDefault(e => e.BanglaiId == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Bang lai voi Id = " + id.ToString() + " khong co de xoa");
                    }
                    else
                    {
                        context.Banglais.Remove(entity);
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
    }
}
