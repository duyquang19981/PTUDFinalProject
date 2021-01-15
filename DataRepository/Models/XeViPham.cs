using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataRepository
{
    public class XeViPham
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int XeId { get; set; }
        public string BienSoXe { get; set; }
        public string Hang { get; set; }
        public string Loai { get; set; }
        public string MauSac { get; set; }
        public int Nam { get; set; }
        public string TrangThai { get; set; }
        public virtual Chuxe Chuxe { get; set; }
    }
}