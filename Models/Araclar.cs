namespace Ege.Models{
public class Araclar {
    public AracDetay AracDetay { get; set; }
    public int Id {get; set;}
    public int Yil {get; set;}
    public required string Marka {get; set;}
    public required string Model {get; set;}
    public decimal Fiyat {get; set;}
    
    public ICollection<Kullanicilar> Kullanicilar { get; set; } = new List<Kullanicilar>();
}
}