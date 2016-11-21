using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    
    public class UrunlerModel
    {
        [Key]
        public int UrunlerModelID { get; set; }
        public string UrunAdi { get; set; }
        public string UrunResmiURL { get; set; }
        public string UrunOzellikleri { get; set; }
        public string UrunTanitimVideosu { get; set; }
        public decimal Fiyat { get; set; }
        //[ForeignKey("Kat")]
        public int KategoriID { get; set; }
       

        //public virtual KategoriModel Kat { get; set; }
       


    }
}
