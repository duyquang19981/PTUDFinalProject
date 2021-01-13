using DataRepository;
using PTUDFinalProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Models
{
    public class TinhTrangDuong
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TenDuong { get; set; }
        public string TrangThai { get; set; }
        public int? KhuVuc_Id { set; get; }
        public virtual KhuVuc KhuVuc { get; set; }
    }
}
