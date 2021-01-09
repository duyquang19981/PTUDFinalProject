using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Models
{
    public class NguoiQuanLyGT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Ten { get; set; }
        public string NgaySinh { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public virtual ICollection<DenGT_ThayDoi> DenGT_ThayDois { get; set; } = new HashSet<DenGT_ThayDoi>();
    }
}
