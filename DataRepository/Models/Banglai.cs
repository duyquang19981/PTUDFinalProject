using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Models
{
    public class Banglai
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int BanglaiId { get; set; }
        [Required]
        public string LoaiBang { get; set; }
        public string ThongTin { get; set; }
        public ICollection<ChuXevaBangLai> ChuxevaBanglais { get; set; }
    }
}
