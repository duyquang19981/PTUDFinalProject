using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PTUDFinalProject;
using DataRepository;
using DataRepository.Models;
using WebAPI.Controllers;
using Moq;
using System.Web.Http;

namespace UnitTest_TraCuuLuat
{
    [TestClass]
    public class UnitTest_TraCuuLuat
    {
        [TestMethod]
        public void LayTatCaLuat()
        {
            var controller = new LuatGiaoThongController();
            var result = controller.Get() as List<LuatGiaoThong>;
            Assert.AreEqual(19, result.Count);

            string now = DateTime.Now.ToString();
            Console.WriteLine(now);
        }

        [TestMethod]
        public void LayLuatTheoID()
        {
            var controller = new LuatGiaoThongController();
            var result = controller.GetID(2) as List<LuatGiaoThong>;
            Assert.IsNotNull(result);
            Assert.AreEqual(1,result.Count);

            string now = DateTime.Now.ToString();
            Console.WriteLine(now);
        }

        [TestMethod]
        public void TraCuuLuatTheoTuKhoa()
        {
            var controller = new LuatGiaoThongController();
            var result = controller.Search("xi") as List<LuatGiaoThong>;
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);

            string now = DateTime.Now.ToString();
            Console.WriteLine(now);
        }
    }
}
