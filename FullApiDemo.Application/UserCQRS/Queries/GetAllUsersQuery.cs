using FullApiDemo.Application.Common.Interfaces;
using FullApiDemo.Application.UserCQRS.Dtos;
using FullApiDemo.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullApiDemo.Application.UserCQRS.Queries
{
	public class GetAllUsersQuery : IRequest<GetAllUsersQueryResponseDto>
	{
		public bool IsGetAll { get; set; }
	}

	public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, GetAllUsersQueryResponseDto>
	{
		private readonly IApplicationDbContext _applicationDbContext;

		public GetAllUsersQueryHandler(IApplicationDbContext applicationDbContext) 
		{ 
			_applicationDbContext = applicationDbContext;
		}

		public async Task<GetAllUsersQueryResponseDto> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
		{
			var response = new GetAllUsersQueryResponseDto();

			try
			{
				if(request.IsGetAll)
				{
					var users = await _applicationDbContext.User.AsNoTracking().ToListAsync(cancellationToken);

					if (users.Count == 0 || users == null)
					{
						throw new Exception();
					}

					response.TotalCount = users.Count;
					response.Users = users.Select(u => new GetUserItemQueryResponseDto()
					{
						Id = u.Id,
						Name = u.Name,
						Email = u.Email,
					}).ToList();
				}

				return response;
				
			}
			catch (Exception e)
			{
				response.TotalCount = 0;
				response.Users = null;

				return response;
			}
		}
	}
}
