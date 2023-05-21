using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FullApiDemo.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public abstract class ApiController : ControllerBase
	{
		private ISender _mediator = null!;

		protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
	}
}
