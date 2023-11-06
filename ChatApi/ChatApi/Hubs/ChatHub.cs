using ChatApi.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace ChatApi.Hubs
{
    public class ChatHub : Hub
    {
        private readonly AppDbContext appDbContext;

        public ChatHub(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public void Refresh(string message)
        {
            Clients.All.SendAsync("Data", message);
        }
    }
}