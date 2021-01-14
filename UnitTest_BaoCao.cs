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


namespace GTVT.Tests
{
    [TestClass]
    public class UnitTest_BaoCao
    {
        [TestMethod]
        public void LayTatCaBaoCao()
        {
            var testBaoCao = GetTestBaoCao();
            var controller = new BaoCaoController();
            var result = controller.Get() as List<BaoCao>;
            Assert.AreEqual(testBaoCao.Count, result.Count);
        }

        [TestMethod]
        public void LayBaoCaoTheoCMND()
        {
            var testBaoCao = GetTestBaoCao_CMND();
            var controller = new BaoCaoController();
            var result = controller.Get(123456789) as List<BaoCao>;
            Assert.IsNotNull(result);
            Assert.AreEqual(testBaoCao.Count, result.Count);
        }
        [TestMethod]
        public void LayDanhSachViPhamCuaBaoCaoTheoId()
        {
            var controller = new BaoCaoController();
            var result = controller.GetDSViPham(1) as List<LuatGiaoThong>;
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void KiemTraXoaThanhCong()
        {
            var mock = new Mock<BaoCao>();
            var controller = new BaoCaoController(mock.Object);

            IHttpActionResult actionResult = controller.Delete(5);

            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }

        [TestMethod]
        public void KiemTraKhoiTaoBaoCao()
        {
            var mock = new Mock<BaoCao>();
            var controller = new BaoCaoController(mock.Object);

            IHttpActionResult actionResult=controller.Post(new BaoCao { NguoiViPham = 100, DiaDiemPhat = "Fuk u", ThoiGianLap = "11/1/2021", TienPhat = 999, TinhTrangNopPhat = "Chua" });
            
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }

        [TestMethod]
        public void KiemTraCapNhatBaoCao()
        {
            var mock = new Mock<BaoCao>();
            var controller = new BaoCaoController(mock.Object);

            IHttpActionResult actionResult = controller.Put(9, new BaoCao { NguoiViPham = 100, DiaDiemPhat = "Fuk me pls", ThoiGianLap = "11/1/2021", TienPhat = 999, TinhTrangNopPhat = "Chua" });

            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }


        private List<BaoCao> GetTestBaoCao()
        {
            var testBaoCaos = new List<BaoCao>();
            testBaoCaos.Add(new BaoCao { Id = 1, NguoiViPham = 1, DiaDiemPhat = "Nguyen Van Cu", ThoiGianLap = "11/1/2021", TienPhat = 100, TinhTrangNopPhat = "Chua" });
            testBaoCaos.Add(new BaoCao { Id = 2, NguoiViPham = 2, DiaDiemPhat = "Linh Trung", ThoiGianLap = "10/1/2021", TienPhat = 200, TinhTrangNopPhat = "Chua" });
            testBaoCaos.Add(new BaoCao { Id = 3, NguoiViPham = 3, DiaDiemPhat = "Thu Duc", ThoiGianLap = "9/1/2021", TienPhat = 300, TinhTrangNopPhat = "Chua" });

            return testBaoCaos;
        }

        private List<BaoCao> GetTestBaoCao_CMND()
        {
            var testBaoCaos = new List<BaoCao>();
            testBaoCaos.Add(new BaoCao { Id = 1, NguoiViPham = 1, DiaDiemPhat = "Nguyen Van Cu", ThoiGianLap = "11/1/2021", TienPhat = 100, TinhTrangNopPhat = "Chua" });
            return testBaoCaos;
        }
    }
}
