using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullApiDemo.Application.UserCQRS.Dtos
{
	public class GetAllUsersQueryResponseDto
	{
		public int TotalCount { get; set; }

		public List<GetUserItemQueryResponseDto>? Users { get; set; }

	}

	public class GetUserItemQueryResponseDto
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Email { get; set; }
	}
}
