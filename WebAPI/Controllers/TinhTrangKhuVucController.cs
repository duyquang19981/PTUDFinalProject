using DataRepository.Models;
using PTUDFinalProject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class TinhTrangKhuVucController : ApiController
    {
        // GET: api/TinhTrangKhuVuc
        // GET: api/TinhTrangDuong
        public IEnumerable<TinhTrangDuong> Get()
        {
            GTVTContext context = new GTVTContext();
            var lstTinhTrangDuong = context.TinhTrangDuongs.ToList();
            return lstTinhTrangDuong;

        }
        public TinhTrangDuong Get(int id)
        {
            GTVTContext context = new GTVTContext();
            var TinhTrangDuong = context.TinhTrangDuongs
                     .Where(b => b.KhuVuc_Id == id)
                     .FirstOrDefault();
            return TinhTrangDuong;
        }

        // POST: api/TinhTrangKhuVuc
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TinhTrangKhuVuc/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TinhTrangKhuVuc/5
        public void Delete(int id)
        {
        }
    }
}
