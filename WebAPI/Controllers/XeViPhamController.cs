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
    public class XeViPhamController : ApiController
    {
        Xe dataRepository;
        public XeViPhamController(Xe data)
        {
            dataRepository = data;
        }

        List<Xe> Xes = new List<Xe>();
        public XeViPhamController() { }

        public XeViPhamController(List<Xe> Xes)
        {
            this.Xes = Xes;
        }
        // GET: api/XeViPham
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("api/{idXe}/Chuxe")]
        [HttpGet]
        public IEnumerable<Chuxe> GetChuXeViPham(int idXe)
        {
            GTVTContext context = new GTVTContext();
            var Xe = (from l in context.Chuxes
                                  join vp in context.Xes on l.ChuxeId equals vp.ChuxeId
                                  where vp.XeId == idXe
                                  select l).ToList();

            return Xe;
        }

        // GET: api/XeViPham/5
        //public IEnumerable<Xe> Get(int id)
        //{
        //    GTVTContext context = new GTVTContext();
        //    var Xe = context.Xes
        //             .Where(b => b.XeId == id)
        //            .ToList();
        //    return Xe;
        //}

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
