using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class KategoriModel
    {

        [Key]
        public int KategoriModelID { get; set; }
       
        public string KategoriAdi { get; set; }
    }
}
