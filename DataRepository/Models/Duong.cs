﻿using DataRepository;
using PTUDFinalProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Models
{
    public class Duong : IEquatable<Duong>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TenDuong { get; set; }
        public virtual ICollection<KhuVuc> KhuVucs { get; set; } = new HashSet<KhuVuc>();
        public virtual ICollection<TinhTrangDuong> TinhTrangDuongs { get; set; } = new HashSet<TinhTrangDuong>();

        public bool Equals(Duong other)
        {
            return this.Id == other.Id;
        }
    }
}
