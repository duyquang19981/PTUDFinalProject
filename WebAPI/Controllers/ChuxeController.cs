using DataRepository;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ChuxeController : ApiController
    {
    
        // GET: api/Chuxe
        public IEnumerable<Chuxe> Get()
        {
            GTVTContext context = new GTVTContext();
            var lstChuxe = context.Database.SqlQuery<Chuxe>("exec sp_laychuxe").ToList();
            return lstChuxe;
        }

        // GET: api/Chuxe/5
        public IEnumerable<Chuxe> Get(int Id)
        {
            GTVTContext context = new GTVTContext();

            var cmdText = "sp_xemchuxe_theoid @Id = @id_param";
            var sqlParams = new[]{
            new SqlParameter("id_param", Id) };
            var lstChuxe = context.Database.SqlQuery<Chuxe>(cmdText, sqlParams).ToList();
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
                        chuxe.Id.ToString());

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
                    var entity = context.Chuxes.FirstOrDefault(e => e.Id == id);
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
                    var entity = context.Chuxes.FirstOrDefault(e => e.Id == id);
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




    }
}
