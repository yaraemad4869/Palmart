﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Palmart.Data.Enums;

namespace Palmart.Models
{
    public class Order
	{
		[Key]
		public int ID { get; set; }
		public DateTime OrderDate { get; set; }
		public decimal OrderPrice { get; set; }
		public decimal DeliveryFee { get; set; }
		[MaxLength(20)]
		public string DiscountCode { get; set; }
		[MaxLength(100)]
		public string OrderAddress { get; set; }
		public OrderStatus OrderStatus { get; set; }
		[ForeignKey("user")]
		public int UserID { get; set; }
		public User user { get; set; }
		[ForeignKey("employee")]
		public int EmpID { get; set; }
		public Employee employee { get; set; }
		public ICollection<OrderProduct>? OrderProducts { get; set; }

	}
}

