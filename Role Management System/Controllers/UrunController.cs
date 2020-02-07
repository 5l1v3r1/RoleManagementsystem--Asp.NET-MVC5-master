using Role_Management_System.Models;
using Role_Management_System.ServiceReference1;
using Role_Management_System.ServiceReference2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Role_Management_System.Controllers
{
    [Authorize]
    public class UrunController : Controller
    {
        // GET: Urun

        public ActionResult Index()
        {
            List<UrunViewModel> mymodel = new List<UrunViewModel>();
            UrunServisClient urunServis = new UrunServisClient();
            //// Bütün kategorileri çekmek için

            //List<Kategori> kategoriler = urunServis.SelectKategori("mNRsaGrsdpmrkpKeqqJfQbP0RM", 0, "tr");
            //foreach (var kategori in kategoriler)
            //{
            //    Console.WriteLine("Kategori Adı: " + kategori.Tanim);
            //}
            //// Tek bir kategoriyi çekmek için
            //List<Kategori> tekKategori = urunServis.SelectKategori("mNRsaGrsdpmrkpKeqqJfQbP0RM", 53, "tr");
            //Console.WriteLine("Kategori Adı: " + tekKategori[0].Tanim);
            // Filtre değerleri:
            // -1 : Filtre yok
            // 0 : false
            // 1 : true
            // Bu değerler 'Aktif','Firsat','indirimli' ve 'Vitrin' için geçerlidi

            UrunFiltre urunFiltre = new UrunFiltre{
                Aktif = -1,
                Firsat = -1,
                
                Indirimli = -1,
                Vitrin = -1,
                KategoriID = 0, // 0 gönderilirse filtre yapılmaz.
                MarkaID = 0, // 0 gönderilirse filtre yapılmaz.
                UrunKartiID = 0,//0 gönderilirse filtre yapılmaz.
                //Barkod="1564654812", //barkod girilirse sadece o barkodlu ürün gelir.
                //ToplamStokAdediBas = 0,
                //ToplamStokAdediSon = 5000,
                TedarikciID = 0, // 0 gönderilirse filtre yapılmaz
                };
            UrunSayfalama urunSayfalama = new UrunSayfalama{BaslangicIndex = 0, // Başlangıç değeri
                KayitSayisi = 100, // Bir sayfada görüntülenecek ürün sayısı
                SiralamaDegeri = "ID", // Hangi sütuna göre sıralanacağı
                SiralamaYonu = "ASC", // Artan "ASC", azalan "DESC"               
            };
            
            List<UrunKarti> FiltrelenenUrunKartiListe = urunServis.SelectUrun("mNRsaGrsdpmrkpKeqqJfQbP0RM", urunFiltre, urunSayfalama);
            foreach (var item in FiltrelenenUrunKartiListe)
            {
                
               
                List<Varyasyon> varyasyonListe = item.Varyasyonlar;
                foreach (var itemVar in varyasyonListe)
                {
                    UrunViewModel urunListItem = new UrunViewModel();
                    urunListItem.ID = item.ID;
                    urunListItem.StokKodu = itemVar.StokKodu;
                    urunListItem.Kategori = item.AnaKategori;
                    urunListItem.Marka = item.Marka;
                    urunListItem.StokAdedi = itemVar.StokAdedi;
                    urunListItem.UrunAdi = item.UrunAdi;
                    
                    urunListItem.Fiyat = itemVar.SatisFiyati;
                    urunListItem.varID = itemVar.ID;
                    urunListItem.varAdi = itemVar.Ozellikler[0].Deger;
                    mymodel.Add(urunListItem);
                }


            }

            return View(mymodel);
        }

        [HttpPost]
        public string UrunStokUpdate(string urunVarId,string urunStok) {

            UrunServisClient urunServisClient = new UrunServisClient(); 
            List<Varyasyon> urunListe = new List<Varyasyon>();// id ve stok adedi göndermek yeterlidir. 
            Varyasyon varyasyon = new Varyasyon{
                ID= Convert.ToInt32(urunVarId),
                StokAdedi= Convert.ToInt32(urunStok)
                    };
            urunListe.Add(varyasyon);
            int sonuc= urunServisClient.StokAdediGuncelle("mNRsaGrsdpmrkpKeqqJfQbP0RM", urunListe);
            if (sonuc<1)
            {
                return "Hatalı";
            }
            return "basarili";
        }
    }
}