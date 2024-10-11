﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Palmart.Data.Enums;

namespace Palmart.Models
{
	public class Payment
	{
		[Key]
		public int ID { get; set; }
		public DateTime PaymentDate { get; set; }
		public decimal TotalPrice { get; set; }
		[EnumDataType(typeof(PaymentMethod))]
		public PaymentMethod PaymentMethod { get; set; }
		[EnumDataType(typeof(PaymentStatus))]
		public PaymentStatus PaymentStatus { get; set; }
		[ForeignKey("user")]
		public int UserID { get; set; }
		public User user { get; set; }
	}
}
