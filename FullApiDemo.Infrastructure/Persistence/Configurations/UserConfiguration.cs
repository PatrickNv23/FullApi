using FullApiDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullApiDemo.Infrastructure.Persistence.Configurations
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasKey(u => u.Id);
			builder.Property(u => u.Name).IsRequired().HasColumnType("varchar(max)");
			builder.Property(u => u.Email).IsRequired();
			builder.Property(u => u.Password).IsRequired();
			builder.Property(u => u.Phone).IsRequired().HasMaxLength(9);
		}
	}
}
