using PTUDFinalProject;
using PTUDFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class KhuVucController : ApiController
    {
        // GET: api/KhuVuc
        public IEnumerable<KhuVuc> Get()
        {
            GTVTContext context = new GTVTContext();
            var lstKhuVuc = context.KhuVucs.ToList();
            return lstKhuVuc;

        }

        // GET: api/KhuVuc/5
        public KhuVuc Get(int id)
        {
            GTVTContext context = new GTVTContext();
            var KhuVuc = context.KhuVucs
                     .Where(b => b.Id == id)
                     .FirstOrDefault();
            return KhuVuc;
        }

        // POST: api/KhuVuc
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/KhuVuc/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/KhuVuc/5
        public void Delete(int id)
        {
        }
    }
}
