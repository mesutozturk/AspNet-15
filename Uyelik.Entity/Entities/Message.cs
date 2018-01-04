using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Uyelik.Entity.IdentityModels;

namespace Uyelik.Entity.Entities
{
    [Table("Messages")]
    public class Message
    {
        [Key]
        public long Id { get; set; }
        public DateTime MessageDate { get; set; } = DateTime.Now;
        [Required]
        public string Content { get; set; }
        [Required]
        public string SendBy { get; set; }
        [Required]
        public string SentTo { get; set; }


        [ForeignKey("SendBy")]
        public virtual ApplicationUser Sender { get; set; }
    }
}
