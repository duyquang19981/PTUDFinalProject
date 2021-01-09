using DataRepository;
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
    public class TinhTrangController : ApiController
    {
        // GET: api/TinhTrang
        public IEnumerable<TinhTrang> Get()
        {
            GTVTContext context = new GTVTContext();
            var lstTinhTrang = context.TinhTrangs.ToList();
            return lstTinhTrang;
        }

        // GET: api/TinhTrang/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TinhTrang
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TinhTrang/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TinhTrang/5
        public void Delete(int id)
        {
        }
    }
}
