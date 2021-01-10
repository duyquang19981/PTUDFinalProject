using PTUDFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataRepository
{
    public class ViPhamLuatGT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Id_BaoCao { get; set; }
        public BaoCao BaoCao { get; set; }
        public int Id_LuatGiaoThong { get; set; }
        public LuatGiaoThong LuatGiaoThong { get; set; }
    }
}
