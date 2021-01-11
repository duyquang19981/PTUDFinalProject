using DataRepository;
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
    public class LuatGiaoThongController : ApiController
    {
        // GET: api/LuatGiaoThong
        public IEnumerable<LuatGiaoThong> Get()
        {
            GTVTContext context = new GTVTContext();
            var lstLuatGiaoThong = context.LuatGiaoThongs.ToList();
            return lstLuatGiaoThong;
        }

        // GET: api/LuatGiaoThong/5
        public LuatGiaoThong Get(int id)
        {
            GTVTContext context = new GTVTContext();
            var LuatGiaoThong = context.LuatGiaoThongs
                     .Where(b => b.Id == id)
                     .FirstOrDefault();
            return LuatGiaoThong;
        }

        // POST: api/LuatGiaoThong
        public void Post([FromBody]string value)
        {

        }

        // PUT: api/LuatGiaoThong/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/LuatGiaoThong/5
        public void Delete(int id)
        {
            
        }
    }
}
