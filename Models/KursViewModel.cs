using EntityFremworkApp.Data;


namespace EntityFremworkApp.Models
{
    public class KursViewModel
    {

        public int KursId { get; set; }
        public string? Baslik { get; set; }

        public int? OgretmenId { get; set; }

        public ICollection<KursKayit> KursKayitleri { get; set; } = new List<KursKayit>();
    }
}