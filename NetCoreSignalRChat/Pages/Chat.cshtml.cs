using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NetCoreSignalRChat.Pages
{
	[Authorize]
	public class ChatModel : PageModel
	{
		public void OnGet()
		{
		}
	}
}