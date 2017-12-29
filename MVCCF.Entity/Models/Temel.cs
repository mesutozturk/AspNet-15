using System;
using System.ComponentModel.DataAnnotations;

namespace MVCCF.Entity.Models
{
    public abstract class Temel<T> : ITemel
    {
        [Key]
        public T Id { get; set; }
        public bool AktifMi { get; set; } = true;
        public DateTime EklenmeTarihi { get; set; } = DateTime.Now;
    }
}
