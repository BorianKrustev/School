using System;
using System.Collections.Generic;
using System.Text;
using BillsPaymentSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillsPaymentSystem.Data.EntityConfiguration
{
	public class BankAccountConfig : IEntityTypeConfiguration<BankAccount>
	{
		public void Configure(EntityTypeBuilder<BankAccount> builder)
		{
			builder.Property(x => x.BankName)
				.HasMaxLength(50)
				.IsUnicode()
				.IsRequired();

			builder.Property(x => x.SWIFT)
				.HasMaxLength(20)
				.IsUnicode(false)
				.IsRequired();
		}
	}
}
