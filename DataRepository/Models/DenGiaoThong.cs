using PTUDFinalProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository
{
    public class DenGiaoThong
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Do { get; set; }
        public int Vang { get; set; }
        public int Xanh { get; set; }
        public int TrangThai { get; set; }
        public int Id_KhuVuc { get; set; }
        public virtual KhuVuc KhuVuc { get; set; }
    }
}
