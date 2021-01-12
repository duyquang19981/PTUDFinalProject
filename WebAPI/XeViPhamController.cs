using ChucNang10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class XeViPhamController : ApiController
    {
        // GET: api/XeViPham
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/XeViPham/5
        public XeViPham Get(int id)
        {
            GTVTContext context = new GTVTContext();
            var XeViPham = context.XeViPhams
                     .Where(b => b.XeId == id)
                     .FirstOrDefault();
            return XeViPham;
        }

        // POST: api/XeViPham
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/XeViPham/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/XeViPham/5
        public void Delete(int id)
        {
        }
    }
}
