namespace Ege.Models{
public class Kullanicilar {
    public int Id { get; set;}
    public  string? Ad {get; set;}
    public  string Soyad {get; set;}
    public int Yas {get; set;}

    public int AracId {get; set;}
    public Araclar Arac {get; set;}
}
}