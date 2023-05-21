using FullApiDemo.Application.Common.Interfaces;
using FullApiDemo.Application.Common.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullApiDemo.Application.UserCQRS.Commands
{
	public class CreateUserCommand : IRequest<BaseResponseModel>
	{
		public string? Name { get; set; }
		public string? Email { get; set; }
		public string? Password { get; set; }
		public string? Phone { get; set; }
	}

	public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, BaseResponseModel>
	{
		private readonly IApplicationDbContext _applicationDbContext;

		public CreateUserCommandHandler(IApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		public async Task<BaseResponseModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
		{
			var response = new BaseResponseModel();

			try
			{
				if(request == null || string.IsNullOrEmpty(request.Name?.Trim()))
				{
					throw new Exception("El body enviado es null");
				}

				await _applicationDbContext.User.AddAsync(new Domain.Entities.User()
				{
					Name = request.Name,
					Email = request.Email,
					Password = request.Password,
					Phone = request.Phone
				});

				await _applicationDbContext.SaveChangesAsync(cancellationToken);

				response.IsError = false;
				response.Message = "Se ha creado el usuario correctamente";

				return response;
			}
			catch (Exception ex)
			{
				response.Message = ex.Message;

				return response;
			}
		}
	}
}
