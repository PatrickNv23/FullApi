using FullApiDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullApiDemo.Application.Common.Interfaces
{
	public interface IApplicationDbContext
	{

		DbSet<User> User { get; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
