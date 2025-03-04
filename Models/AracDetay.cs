
namespace Ege.Models
{
    public class AracDetay
    {
        public int arac_ıd { get; set; } 
        public Araclar Arac { get; set; }  

        public int ID { get; set; }
        public int motorH { get; set; }
        public int koltukSay { get; set; }
        public string degisenParca { get; set; }
        public int tramerKaydı { get; set; }
        public string renk { get; set; }
        public int hp { get; set; }
        public int tork { get; set; }

    
    }
}