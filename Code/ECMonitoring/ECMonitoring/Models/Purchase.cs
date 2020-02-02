using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECMonitoring.Models
{
    [Table("Purchases", Schema = "dbo")]
    public class Purchase
    {
        [Column("PurchaseId")]
        public Guid Id { get; set; }
        [Column("Person")]
        public string Person { get; set; }
        [Column("Address")]
        public string Address { get; set; }
        [Column("BookId")]
        public Guid BookId { get; set; }
        [Column("Date")]
        public DateTime Date { get; set; }
    }
}