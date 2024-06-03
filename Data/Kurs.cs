using System.ComponentModel.DataAnnotations;

namespace EntityFremworkApp.Data
{
    public class Kurs
    {
        [Key]
        public int KursId { get; set; }
        public string? Baslik { get; set; }

        public int? OgretmenId { get; set; }

        public Ogretmen Ogretmen { get; set; } = null!;
        public ICollection<KursKayit> KursKayitleri { get; set; } = new List<KursKayit>();
    }
}