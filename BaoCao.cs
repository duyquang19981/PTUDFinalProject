using PTUDFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataRepository
{
    public class BaoCao
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int NguoiViPham { get; set; }
        public string DiaDiemPhat { get; set; }
        public string ThoiGianLap { get; set; }
        public int TienPhat { get; set; }
        public string TinhTrangNopPhat { get; set; }
        public ICollection<ViPhamLuatGT> ViPhamLuatGTs { get; set; }
    }
}
