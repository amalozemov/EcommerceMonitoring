using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECMonitoring.Models
{
    [Table("Books", Schema = "dbo")]
    public class Book
    {
        [Column("BookId")]
        public Guid Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Author")]
        public string Author { get; set; }
        [Column("Price")]
        public int Price { get; set; }
    }
}