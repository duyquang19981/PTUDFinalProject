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

    public class TinhTrangDuong : IEquatable<TinhTrangDuong>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime ThoiGian { get; set; }

        public bool Equals(TinhTrangDuong other)
        {
            throw new NotImplementedException();
        }
    }
}
