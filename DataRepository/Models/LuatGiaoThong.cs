using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChucNang10
{
    public class LuatGiaoThong
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NoiDungLuat { get; set; }
        public int LanCapNhat { get; set; }
        public string NgayCapNhat { get; set; }
        public int MucPhat { get; set; }
    }
}
