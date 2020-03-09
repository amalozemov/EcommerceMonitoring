using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECMonitoring.Models.EcMonitoring
{
    [Table("Metrics", Schema = "dbo")]
    public class Metric
    {
        [Column("Id")]
        public Guid Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Description")]
        public string Description { get; set; }
    }
}