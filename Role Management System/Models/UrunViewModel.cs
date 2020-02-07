using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Role_Management_System.Models
{
    public class UrunViewModel
    {
        public int ID { get; set; }
        public string StokKodu { get; set; }
        public string UrunAdi { get; set; }
        public string Marka { get; set; }
        public string Kategori { get; set; }
        public double Fiyat { get; set; }
        public double StokAdedi { get; set; }

        public string varAdi { get; set; }
        public int varID { get; set; }
    }
}