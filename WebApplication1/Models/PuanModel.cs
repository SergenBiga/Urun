using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class PuanModel
    {
        [Key]
        public int PuanModelID { get; set; }
        public string KullanıcıID { get; set; }
        [ForeignKey("Yıldız")]
        public int UrunID { get; set; }
        public int Puan { get; set; }

        public virtual UrunlerModel Yıldız { get; set; }
    }
}
