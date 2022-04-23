using System;
using System.Collections.Generic;

#nullable disable

namespace EF_CODE_Deneme.Models
{
    public partial class Kitaplar
    {
        public Kitaplar()
        {
            Oduncs = new HashSet<Odunc>();
        }

        public string Isbn { get; set; }
        public string Ad { get; set; }
        public int? SayfaSayisi { get; set; }
        public int? Stok { get; set; }
        public int? TurlerId { get; set; }
        public int? YazarlarId { get; set; }
        public int? YayinEvleriId { get; set; }

        public virtual Turler Turler { get; set; }
        public virtual Yayinevleri YayinEvleri { get; set; }
        public virtual Yazarlar Yazarlar { get; set; }
        public virtual ICollection<Odunc> Oduncs { get; set; }
    }
}
