using Ege.Models;
namespace Ege.ViewModels
{
    public class AraclarKullanici
    {
        public List<Araclar> Araclar { get; set; }
        public List<Kullanicilar> Kullanicilar { get; set; }
        public List<AracDetay> AracDetay { get; set; }
    }
    
}