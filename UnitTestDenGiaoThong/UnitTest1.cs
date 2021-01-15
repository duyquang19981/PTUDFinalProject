using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataRepository;
using WebAPI.Controllers;
using PTUDFinalProject;
using Moq;
using System.Web.Http;
using PTUDFinalProject.Models;

namespace UnitTestDenGiaoThong
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LayDSKhuVuc()
        {
            var controller = new KhuVucController();
            var result = controller.Get() as List<KhuVuc>;
            Assert.AreEqual(4, result.Count);
            string now = DateTime.Now.ToString();
            Console.WriteLine(now);
        }


        [TestMethod]
        public void LayKhuVucTheoID()
        {
           // var testBaoCao = GetTestBaoCao_CMND();
            var controller = new KhuVucController();
            var result = controller.Get(1) as KhuVuc;
            Assert.IsNotNull(result);
            Assert.AreEqual( "Quận 1", result.TenKhuVuc);
            string now = DateTime.Now.ToString();
            Console.WriteLine(now);
        }


        [TestMethod]
        public void KiemTraThemKhuVuc()
        {
            var mock = new Mock<KhuVuc>();
            var controller = new KhuVucController(mock.Object);

            IHttpActionResult actionResult = controller.Post(new KhuVuc {  TenKhuVuc = "Quận 5" });

            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
            string now = DateTime.Now.ToString();
            Console.WriteLine(now);
        }

        [TestMethod]
        public void KiemTraCapNhatKhuVuc()
        {
            var mock = new Mock<KhuVuc>();
            var controller = new KhuVucController(mock.Object);

            IHttpActionResult actionResult = controller.Put(9, new KhuVuc { TenKhuVuc = "Quận 454" });

            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
            string now = DateTime.Now.ToString();
            Console.WriteLine(now);
        }
        [TestMethod]
        public void KiemTraXoaKhuVuc()
        {
            var mock = new Mock<KhuVuc>();
            var controller = new KhuVucController(mock.Object);

            IHttpActionResult actionResult = controller.Delete(9);

            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
            string now = DateTime.Now.ToString();
            Console.WriteLine(now);
        }

    }
}

