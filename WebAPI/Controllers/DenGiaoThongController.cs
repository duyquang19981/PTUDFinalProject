using DataRepository;
using PTUDFinalProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class DenGiaoThongController : ApiController
    {
        // GET: api/DenGiaoThong
        public IEnumerable<DenGiaoThong> Get()
        {
            GTVTContext context = new GTVTContext();
            var lstDenGiaoThong = context.DenGiaoThongs.ToList();
            return lstDenGiaoThong;

        }

        // GET: api/DenGiaoThong/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DenGiaoThong
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/DenGiaoThong/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DenGiaoThong/5
        public void Delete(int id)
        {
        }
    }
}
