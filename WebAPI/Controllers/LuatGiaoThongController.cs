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
        //public IEnumerable<LuatGiaoThong> LuatGiaoThongs { get; private set; }
        LuatGiaoThong dataRepository;
        public LuatGiaoThongController(LuatGiaoThong data)
        {
            dataRepository = data;
        }

        List<LuatGiaoThong> Luats = new List<LuatGiaoThong>();
        public LuatGiaoThongController() { }

        public LuatGiaoThongController(List<LuatGiaoThong> Luats)
        {
            this.Luats = Luats;
        }

        // GET: api/LuatGiaoThong
        public IEnumerable<LuatGiaoThong> Get()
        {
            GTVTContext context = new GTVTContext();
            var lstLuatGiaoThong = context.LuatGiaoThongs.ToList();
            return lstLuatGiaoThong;
        }

        // GET: api/LuatGiaoThong/5
        public IEnumerable<LuatGiaoThong> GetID(int id)
        {
            GTVTContext context = new GTVTContext();
            var lstLuatGiaoThong = context.LuatGiaoThongs
                     .Where(b => b.Id == id).ToList(); ;
            return lstLuatGiaoThong;
        }
        // SEARCH: api/LuatGiaoThong/search/xi
        [HttpGet]
        [Route("api/LuatGiaoThong/search/{str}")]
        public IEnumerable<LuatGiaoThong> Search(string str)
        { 
            GTVTContext context = new GTVTContext();
            var query =(from l in context.LuatGiaoThongs
                         where l.NoiDungLuat.Contains(str)
                         select l).ToList();

            return query;
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
