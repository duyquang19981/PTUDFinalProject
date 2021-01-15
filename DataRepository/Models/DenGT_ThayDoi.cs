using PTUDFinalProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Models
{
    public class DenGT_ThayDoi
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ThoiDiemThayDoi { get; set; }
        public int ThoiGianDoi { get; set; }
        public int Do_TD { get; set; }
        public int Vang_TD { get; set; }
        public int Xanh_TD { get; set; }
        public int TuDong { get; set; }
        public string ThoiGianThucHien { get; set; }
        public int DenGiaoThong_Id { get; set; }
        public virtual DenGiaoThong DenGiaoThong { get; set; }
        public int NguoiQuanLyGT_Id { get; set; }
        public virtual NguoiQuanLyGT NguoiQuanLyGT { get; set; }
    }
}
