using FullApiDemo.Application.Common.ResponseModel;
using FullApiDemo.Application.UserCQRS.Commands;
using FullApiDemo.Application.UserCQRS.Dtos;
using FullApiDemo.Application.UserCQRS.Queries;
using Microsoft.AspNetCore.Mvc;

namespace FullApiDemo.WebAPI.Controllers
{
	public class UserController : ApiController
	{
		[HttpGet]
		public async Task<GetAllUsersQueryResponseDto> GetAllUsers([FromQuery] GetAllUsersQuery query)
		{
			return await Mediator.Send(query);
		}

		[HttpPost]
		public async Task<BaseResponseModel> CreateUser(CreateUserCommand command)
		{
			return await Mediator.Send(command);
		}
	}
}
