using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullApiDemo.Application.Common.ResponseModel
{
	public class BaseResponseModel
	{
		public bool IsError { get; set; }
		public string? Message { get; set; }

		public BaseResponseModel()
		{
			IsError = true;
		}

	}
}
