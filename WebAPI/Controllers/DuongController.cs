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
    public class DuongController : ApiController
    {
        // GET: api/Duong
        public IEnumerable<Duong> Get()
        {
            GTVTContext context = new GTVTContext();
            var lstDuong = context.Duongs.ToList();
            return lstDuong;

        }

        // GET: api/Duong/5
        public Duong Get(int id)
        {
            GTVTContext context = new GTVTContext();
            var Duong = context.Duongs
                     .Where(b => b.Id == id)
                     .FirstOrDefault();
            return Duong;
        }

        // POST: api/Duong
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Duong/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Duong/5
        public void Delete(int id)
        {
        }
    }
}
