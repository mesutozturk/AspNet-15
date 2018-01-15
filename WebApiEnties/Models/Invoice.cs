using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiEntities.Models
{
    [Table("Invoices")]
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        [Range(0, 99999)]
        public decimal Amount { get; set; } = 0;

        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
    }
}
