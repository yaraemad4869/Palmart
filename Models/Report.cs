using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Palmart.Models;

namespace Palmart.Models
{
    public class Report
    {
        [ForeignKey("user")]
        public int UserID { get; set; }
        public User user { get; set; }
        [ForeignKey("product")]
        public int ProductID { get; set; }
        public Product product { get; set; }
		[MaxLength(50)]
		public string ReportReason { get; set; }
        public DateTime ReportDate { get; set; }
    }
}
