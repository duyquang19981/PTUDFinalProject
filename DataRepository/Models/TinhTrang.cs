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
    public class TinhTrang
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TrangThai { get; set; }
        public virtual ICollection<Duong> Duongs { get; set; } = new HashSet<Duong>();
    }
}
