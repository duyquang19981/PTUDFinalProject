﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataRepository { 
    public class LuatGiaoThong
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TieuDeLuat { get; set; }
        public string NoiDungLuat { get; set; }
        public ICollection<ViPhamLuatGT> ViPhamLuatGTs { get; set; }

    }
}
