using Role_Management_System.ServiceReference1;
using Role_Management_System.ServiceReference2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using WebMatrix.WebData;

namespace Role_Management_System
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            //UyeServisClient uyeServis = new UyeServisClient();
            //// Giriş bilgilerini oluşturuyoruz
            //UyeGirisi giris = new UyeGirisi
            //{
            //    Mail = "selin@gulermedya.com",
            //    Sifre = "Liderselin7878",
            //    Admin = true
            //};
            //// Giriş yapıyoruz
            //UyeGirisiSonuc sonuc = uyeServis.GirisYap(giris);
            //if (sonuc.Basarili)
            //{

            //    var temp = sonuc.KullaniciID;

            //}

            //UrunServisClient urunServis = new UrunServisClient();
            //// Bütün kategorileri çekmek için

            //List<Kategori> kategoriler = urunServis.SelectKategori("mNRsaGrsdpmrkpKeqqJfQbP0RM", 0, "tr");
            //foreach (var kategori in kategoriler)
            //{
            //    Console.WriteLine("Kategori Adı: " + kategori.Tanim);
            //}
            //// Tek bir kategoriyi çekmek için
            //List<Kategori> tekKategori = urunServis.SelectKategori("mNRsaGrsdpmrkpKeqqJfQbP0RM", 53, "tr");
            //Console.WriteLine("Kategori Adı: " + tekKategori[0].Tanim);

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AuthenticateWebMatrix();
        }

        private void AuthenticateWebMatrix()
        {
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("Auth", "Users", "UserID", "Username",true);

                //WebSecurity.CreateUserAndAccount("admin", "admin33");
                //Roles.CreateRole("Admin");
                //Roles.CreateRole("Manager");
                //Roles.CreateRole("User");
                //Roles.AddUserToRole("admin", "Admin");
            }
        }
    }
}
