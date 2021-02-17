using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BillsPaymentSystem.Models.Attributes
{
	[AttributeUsage(AttributeTargets.Property)]
	public class ExpirationDateAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var curentDateTime = DateTime.Now;
			var targetDateTime = (DateTime) value;

			if (curentDateTime > targetDateTime)
			{
				return new ValidationResult("Card is expired!");
			}

			return ValidationResult.Success;
		}
	}
}
