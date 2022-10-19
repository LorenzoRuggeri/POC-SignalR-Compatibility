using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace BlazorChatServer
{
	// TODO: AllowAnonymous l'ho aggiunto io.
	//[AllowAnonymous]
	public class ChatHub : Hub
	{
		public const string HubUrl = "/chat";

		public async Task SendMessage(string message)
		{
			// Pubblica il messaggio sulla chat
			await Clients
				.AllExcept(this.Context.ConnectionId)
				.SendAsync("ReceiveMessage", this.Context.ConnectionId, message);
			
			await Clients
				.Caller
				.SendAsync("ReceiveMessage", "You", message);
		}

		public override async Task OnConnectedAsync()
		{
			Console.WriteLine($"{Context.ConnectionId} connected");
			
			await Clients
				.AllExcept(this.Context.ConnectionId)
				.SendAsync("UserConnected", "[System]", $"User '{Context.ConnectionId}' has connected");

			await Clients
				.Caller
				.SendAsync("UserConnected", "[System]", "You are connected");

			await base.OnConnectedAsync();
		}

		public override async Task OnDisconnectedAsync(Exception e)
		{
			Console.WriteLine($"Disconnected {e?.Message} {Context.ConnectionId}");

			await Clients
				.AllExcept(this.Context.ConnectionId)
				.SendAsync("UserDisconnected", "[System]", $"User '{Context.ConnectionId}' has disconnected");

			await base.OnDisconnectedAsync(e);
		}
		
	}
}