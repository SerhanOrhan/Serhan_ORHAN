using System;
using System.Collections.Generic;

#nullable disable

namespace EF_CODE_Deneme.Models
{
    public partial class Uyeler
    {
        public Uyeler()
        {
            Oduncs = new HashSet<Odunc>();
        }

        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string Cinsiyet { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }
        public DateTime? UyelikTarihi { get; set; }
        public int? UyelikTipi { get; set; }
        public string TcNo { get; set; }
        public string Meslek { get; set; }
        public int? EgitimDurumu { get; set; }
        public bool? CezaDurumu { get; set; }

        public virtual ICollection<Odunc> Oduncs { get; set; }
    }
}
