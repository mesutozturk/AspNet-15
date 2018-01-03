using System;
using System.ComponentModel.DataAnnotations;

namespace MVCCF.Entity.Models
{
    public abstract class Temel<T> : ITemel
    {
        [Key]
        public T Id { get; set; }
        [Display(Name ="Aktif Mi")]
        public bool AktifMi { get; set; } = true;
        [Display(Name = "Eklenme Tarihi")]
        public DateTime EklenmeTarihi { get; set; } = DateTime.Now;
    }
}
