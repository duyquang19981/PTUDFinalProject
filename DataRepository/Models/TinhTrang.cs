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

    public class TinhTrang : IEquatable<TinhTrang>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TrangThai { get; set; }
        public virtual ICollection<TinhTrangDuong> TinhTrangDuongs { get; set; } = new HashSet<TinhTrangDuong>();

        public bool Equals(TinhTrang other)
        {
            return this.Id == other.Id;
        }
    }
}
