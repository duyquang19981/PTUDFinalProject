using DataRepository;
using DataRepository.Models;
using PTUDFinalProject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace WebAPI.Controllers
{
    public class XeController : ApiController
    {
        //// GET: api/Xe
        public IEnumerable<Xe> Get()
        {
            GTVTContext context = new GTVTContext();
            var lstXe = context.Xes.ToList();
            return lstXe;
        }

        //// GET: api/Xe/5
        public IEnumerable<Xe> Get(int id)
        {
            GTVTContext context = new GTVTContext();

            //var cmdText = "Exec sp_layxetheoid @Id = @id_param";
            //var sqlParams = new[]{
            //new SqlParameter("id_param", id) };
            //var lstXe = context.Database.SqlQuery<Xe>(cmdText, sqlParams).ToList();
            //return lstXe;

            var lstXe = context.Xes
                       .Where(a => a.XeId == id)
                       .Include(b => b.Chuxe)
                       .ToList();
            return lstXe;
        }




        // POST: api/Xe
        public HttpResponseMessage Post([FromBody] Xe xe)
        {
            try
            {
                using (GTVTContext context = new GTVTContext())
                {
                    context.Xes.Add(xe);
                    context.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, xe);
                    message.Headers.Location = new Uri(Request.RequestUri +
                        xe.XeId.ToString());

                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT: api/Xe/5
        public HttpResponseMessage Put(int id, [FromBody] Xe xe)
        {
            try
            {
                using (GTVTContext context = new GTVTContext())
                {
                    var entity = context.Xes.FirstOrDefault(e => e.XeId == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Xe voi Id " + id.ToString() + " khong co de sua");
                    }
                    else
                    {
                        entity.BienSoXe = xe.BienSoXe;
                        entity.Hang = xe.Hang;
                        entity.Loai = xe.Loai;
                        entity.MauSac = xe.MauSac;
                        entity.Nam = xe.Nam;
                        entity.TrangThai = xe.TrangThai;
                        entity.Chuxe = xe.Chuxe;
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

        // DELETE: api/Xe/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (GTVTContext context = new GTVTContext())
                {
                    var entity = context.Xes.FirstOrDefault(e => e.XeId == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Xe voi Id = " + id.ToString() + " khong co de xoa");
                    }
                    else
                    {
                        context.Xes.Remove(entity);
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
