namespace EntityFremworkApp.Data
{
    public class Ogrenci
    {
        //Id=>primary key
        //[key] metodu farklı bir isimle yapılmak isyediğinde 
        //biirinci anahtar olarak olması için kullanılır
        public int OgrenciId { get; set; }
        public string? OgrenciAd { get; set; }
        public string? OgrencSoyadi { get; set; }
        public string? Eposta { get; set; }
        public string? Telefon { get; set; }
    }
}