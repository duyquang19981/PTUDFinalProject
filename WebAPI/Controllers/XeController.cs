using ChucNang10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class XeController : ApiController
    {
        // GET: api/Xe
        public IEnumerable<Xe> Get()
        {
            GTVTContext context = new GTVTContext();
            var lstXe = context.Xes.ToList();
            return lstXe;

        }

        // GET: api/Xe/5
        public IEnumerable<Xe> Get(int id)
        {
            GTVTContext context = new GTVTContext();
            var lstXe = context.Xes.ToList();
            yield return lstXe[id-1];
        }

        // POST: api/Xe
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Xe/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Xe/5
        public void Delete(int id)
        {
        }
    }
}
