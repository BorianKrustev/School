using System;
using System.Collections.Generic;
using System.Text;
using BillsPaymentSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillsPaymentSystem.Data.EntityConfiguration
{
	public class UserConfig : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			//builder.HasKey(x => x.UserId);

			builder.Property(x => x.FirstName)
				.HasMaxLength(50)
				.IsUnicode()
				.IsRequired();

			builder.Property(x => x.LastName)
				.HasMaxLength(50)
				.IsUnicode()
				.IsRequired();

			builder.Property(x => x.Email)
				.HasMaxLength(80)
				.IsUnicode(false)
				.IsRequired();

			builder.Property(x => x.Password)
				.HasMaxLength(25)
				.IsUnicode(false)
				.IsRequired();
		}
	}
}
