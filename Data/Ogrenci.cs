namespace EntityFremworkApp.Data
{
    public class Ogrenci
    {
        //Id=>primary key
        //[key] metodu farklı bir isimle yapılmak isyediğinde 
        //birinci anahtar olarak olması için kullanılır
        public int OgrenciId { get; set; }
        public string? OgrenciAd { get; set; }
        public string? OgrencSoyadi { get; set; }
        public string? AdSoyad
        {
            get
            {
                return this.OgrenciAd + " " + this.OgrencSoyadi;
            }
        }
        public string? Eposta { get; set; }
        public string? Telefon { get; set; }

        public ICollection<KursKayit> KursKayitleri {get;set;} =new List<KursKayit>();
    }
}