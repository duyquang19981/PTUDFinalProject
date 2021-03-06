﻿using DataRepository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository
{
    public class Chuxe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ChuxeId { get; set; }
        [Required]
        public int CMND { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string GioiTinh { get; set; }
        public int NamSinh { get; set; }

        public virtual ICollection<Xe> Xes { get; set; } = new HashSet<Xe>();
        public ICollection<ChuXevaBangLai> ChuxevaBanglais { get; set; }
        public virtual ICollection<XeViPham> XeViPhams { get; set; } = new HashSet<XeViPham>();


    }
}
