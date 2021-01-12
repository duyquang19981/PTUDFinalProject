using DataRepository;
using DataRepository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTUDFinalProject.Models
{
    public class KhuVuc
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TenKhuVuc { get; set; }
        public virtual ICollection<DenGiaoThong> DenGiaoThongs { get; set; } = new HashSet<DenGiaoThong>();
        public virtual ICollection<Duong> Duongs { get; set; } = new HashSet<Duong>();

        public bool Equals(KhuVuc other)
        {
            return this.Id == other.Id;
        }
    }
}
